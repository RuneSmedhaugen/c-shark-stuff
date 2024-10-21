import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import CategoryList from './CategoryList.jsx';
import LoginDropdown from './LoginDropDown.jsx';
import { artworkService, commentService } from '../services/apiService';
import AuthService from '../services/authService.js';

const Layout = () => {
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const [artworks, setArtworks] = useState([]);
    const [selectedCategory, setSelectedCategory] = useState(null);
    const [error, setError] = useState('');
    const [isDarkMode, setIsDarkMode] = useState(false);
    const [selectedArtwork, setSelectedArtwork] = useState(null);
    const [comments, setComments] = useState([]);
    const [commentText, setCommentText] = useState('');

    useEffect(() => {
        const token = localStorage.getItem('token');
        setIsLoggedIn(!!token);
    }, []);

    const fetchFeaturedArtworks = async () => {
        try {
            const data = await artworkService.getFeaturedArtworks();
            setArtworks(data);
            setError('');
        } catch (error) {
            setArtworks([]);
            setError('Failed to load featured artworks.');
            console.error('Error fetching featured artworks:', error);
        }
    };

    useEffect(() => {
        fetchFeaturedArtworks();
    }, []);

    useEffect(() => {
        const fetchArtworks = async () => {
            if (selectedCategory) {
                try {
                    const data = await artworkService.getArtworksByCategory(selectedCategory);
                    setArtworks(data);
                    setError('');
                } catch (error) {
                    setArtworks([]);
                    setError('This category is empty.');
                    console.error('Error fetching artworks:', error);
                }
            }
        };

        fetchArtworks();
    }, [selectedCategory]);

    const handleCategoryClick = (categoryId) => {
        setSelectedCategory(categoryId);
    };

    const toggleDarkMode = () => {
        setIsDarkMode((prev) => !prev);
    };

    const handleBackToHome = () => {
        setSelectedCategory(null);
        fetchFeaturedArtworks();
    };

    const handleArtworkClick = (artwork) => {
        setSelectedArtwork(artwork);
        fetchComments(artwork.id);
        console.log('Fetched comments:', fetchComments(artwork.id));
    };

    const closeArtworkModal = () => {
        setSelectedArtwork(null);
        setComments([]);
    };

    const fetchComments = async (artworkId) => {
        try {
            const data = await commentService.getCommentsByArtwork(artworkId);
            console.log('Fetched comments:', data);
            setComments(data);
        } catch (error) {
            console.error('Error fetching comments:', error);
        }
    };

    const handleCommentSubmit = async () => {
        if (commentText.trim()) {
            try {
                const userId = localStorage.getItem('userId');
                if (!userId) {
                    console.error('User is not logged in.');
                    return; 
                }
    
                const commentData = {
                    artworkId: selectedArtwork.id,
                    userId: userId, 
                    text: commentText,
                };
                console.log("hehe", userId);
    
                await commentService.addComment(commentData);
                fetchComments(selectedArtwork.id);
                setCommentText('');
            } catch (error) {
                console.error('Error submitting comment:', error);
            }
        }
    };

    return (
        <div className={`layout ${isDarkMode ? 'dark-mode' : ''}`}>
            <div className="top-banner">
                <Link to="/" className="logo">VisionHub</Link>
                <div className="search-section">
                    <input type="text" placeholder="Search artwork..." />
                    <button>Search</button>
                </div>
                <div className="auth-section">
                    {isLoggedIn ? (
                        <div className="options-dropdown">
                            <button className="options-button">Options</button>
                            <div className="dropdown-content">
                                <Link to="/profile">Profile</Link>
                                <button onClick={AuthService.logout()}>Logout</button>
                            </div>
                        </div>
                    ) : (
                        <LoginDropdown />
                    )}
                    <div className="dark-mode-toggle-div">
                        <button className='dark-mode-toggle' onClick={toggleDarkMode}>
                            {isDarkMode ? 'Light Mode' : 'Dark Mode'}
                        </button>
                    </div>
                </div>
            </div>

            <div className="main-content">
                <CategoryList onCategoryClick={handleCategoryClick} />
                <div className="artwork-list">
                    {error && <p style={{ color: 'red' }}>{error}</p>}
                    {artworks.length > 0 ? (
                        <ul>
                            {artworks.map((artwork) => (
                                <div className="artwork-card" key={artwork.id} onClick={() => handleArtworkClick(artwork)}>
                                    <div className="artwork-image-container">
                                        <img className="artwork-image" src={artwork.imageUrl} alt={artwork.title} />
                                    </div>
                                    <div className="artwork-info">
                                        <h3 className="artwork-title">{artwork.title}</h3>
                                        <p className="artwork-description">{artwork.description}</p>
                                    </div>
                                </div>
                            ))}
                        </ul>
                    ) : (
                        <p>No artworks available.</p>
                    )}
                </div>

                {selectedCategory && (
                    <button className="back-to-home" onClick={handleBackToHome}>Back to Homepage</button>
                )}

                {/* Modal for full-size artwork and comments */}
                {selectedArtwork && (
                    <div className="artwork-modal">
                        <div className="modal-content">
                            <button className="close-modal" onClick={closeArtworkModal}>X</button>
                            <h2>{selectedArtwork.title}</h2>
                                <img src={selectedArtwork.imageUrl} alt={selectedArtwork.title} />
                                <div className="artwork-fullsize">
                                <div className="artwork-details">
                                    <p>{selectedArtwork.description}</p>
                                </div>
                            </div>

                            <div className="comments-section">
                                <h3>Comments</h3>
                                <ul>
                                    {comments.map((comment) => (
                                        <li key={comment.id}>
                                            <p><strong>{comment.username}:</strong> {comment.commentText}</p>
                                            <p className="comment-date">{new Date(comment.commentDate).toLocaleString()}</p>
                                        </li>
                                    ))}
                                </ul>
                            
                                    <div className="comment-input">
                                        <textarea
                                            value={commentText}
                                            onChange={(e) => setCommentText(e.target.value)}
                                            placeholder="Write a comment..."
                                        ></textarea>
                                        <button onClick={handleCommentSubmit}>Submit</button>
                                    </div>
                                
                            </div>
                        </div>
                    </div>
                )}
            </div>
        </div>
    );
};

export default Layout;
