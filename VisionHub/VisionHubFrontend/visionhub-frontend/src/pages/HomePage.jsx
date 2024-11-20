import React, { useState, useEffect } from 'react';
import { artworkService, commentService, userService } from '../services/apiService';
import CategoryList from '../components/CategoryList';
import ArtworkList from '../components/ArtworkList';
import ArtworkModal from '../components/ArtworkModal';
import LoginDropDown from '../components/LoginDropDown';
import { useAuth } from '../services/AuthContext';

const HomePage = () => {
    const [artworks, setArtworks] = useState([]);
    const [selectedCategory, setSelectedCategory] = useState(null);
    const [error, setError] = useState('');
    const [selectedArtwork, setSelectedArtwork] = useState(null);
    const [comments, setComments] = useState([]);
    const [commentText, setCommentText] = useState('');
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [isLoginOpen, setIsLoginOpen] = useState(false);
   

    const {currentUser, login } = useAuth();

    const handleLogin = async (username, password) => {
        const success = await login(username, password);
        if (success) {
            setIsLoginOpen(false);
        }
    };

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

    const handleBackToHome = () => {
        setSelectedCategory(null);
        fetchFeaturedArtworks();
    };

    const handleArtworkClick = (artwork) => {
        setSelectedArtwork(artwork);
        fetchComments(artwork.id);
        setIsModalOpen(true);
    };

    const closeArtworkModal = () => {
        setSelectedArtwork(null);
        setComments([]);
        setIsModalOpen(false);
    };

    const fetchComments = async (artworkId) => {
        try {
            const data = await commentService.getCommentsByArtwork(artworkId);
            const commentsWithUsernames = await Promise.all(
                data.map(async (comment) => {
                    const username = await userService.getUser(comment.userID);
                    return {
                        ...comment,
                        username,
                    };
                })
            );
            setComments(commentsWithUsernames);
        } catch (error) {
            console.error('Error fetching comments:', error);
        }
    };

    return (
        <div className="home-page">
            <CategoryList onCategoryClick={handleCategoryClick} />

            {selectedCategory && (
                <button onClick={handleBackToHome}>Back to Home</button>
            )}

            {error && <p>{error}</p>}
            <ArtworkList artworks={artworks} handleArtworkClick={handleArtworkClick} />

            {isModalOpen && selectedArtwork && (
                <ArtworkModal
                    artwork={selectedArtwork}
                    comments={comments}
                    closeModal={closeArtworkModal}
                    handleCommentSubmit={() => commentService.addComment(selectedArtwork.id, commentText)}
                    commentText={commentText}
                    setCommentText={setCommentText}
                    isModalOpen={isModalOpen}
                    currentUser={currentUser}
                />
            )}

            {isLoginOpen && (
                <div className="dropdown-overlay">
                    <LoginDropDown
                        closeModal={() => setIsLoginOpen(false)}
                        handleLogin={handleLogin}
                        isDarkMode={false}
                    />
                </div>
            )}
        </div>
    );
};

export default HomePage;
