import React, { useState, useEffect } from 'react';
import { artworkService, commentService, userService } from '../services/apiService';
import TopBanner from '../components/TopBanner';
import CategoryList from '../components/CategoryList';
import ArtworkList from '../components/ArtworkList';
import ArtworkModal from '../components/ArtworkModal';
import LoginDropDown from '../components/LoginDropDown';
import { authService } from '../services/authService';

const HomePage = () => {
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const [artworks, setArtworks] = useState([]);
    const [selectedCategory, setSelectedCategory] = useState(null);
    const [error, setError] = useState('');
    const [selectedArtwork, setSelectedArtwork] = useState(null);
    const [comments, setComments] = useState([]);
    const [commentText, setCommentText] = useState('');
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [isLoginOpen, setIsLoginOpen] = useState(false);

    useEffect(() => {
        const token = authService.getToken();
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

    const handleBackToHome = () => {
        setSelectedCategory(null);
        fetchFeaturedArtworks();
    };

    const handleArtworkClick = (artwork) => {
        setSelectedArtwork(artwork);
        fetchComments(artwork.id);
        setIsModalOpen(true);
        console.log('IsModalOpen: ', isModalOpen);
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

    const handleLogout = () => {
        authService.logout();
        setIsLoggedIn(false);
    };

    return (
        <div className="home-page">
            <TopBanner
                isLoggedIn={isLoggedIn}
                setIsLoggedIn={setIsLoggedIn}
                setIsLoginOpen={setIsLoginOpen}
                handleLogout={handleLogout}
            />
            <CategoryList onCategoryClick={handleCategoryClick} />
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
                />
            )}
            {isLoginOpen && (
                <div className="dropdown-overlay">
                    <LoginDropDown closeModal={() => setIsLoginOpen(false)} setIsLoggedIn={setIsLoggedIn} isDarkMode={false} />
                </div>
            )}
        </div>
    );
};

export default HomePage;
