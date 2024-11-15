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
    const [currentUser, setCurrentUser] = useState(null);

    useEffect(() => {
        const token = authService.getToken();
        const userId = localStorage.getItem('userid');

        if (token && userId) {
            setIsLoggedIn(true);  // Set login state based on token availability

            // Fetch user details from the API using the userId
            userService.getUser(userId).then((userData) => {
                setCurrentUser(userData);  // Set current user data
            }).catch((error) => {
                console.error('Error fetching user data:', error);
            });
        }
    }, []); // Runs only on initial load

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

    const handleLogout = () => {
        authService.logout();
        setIsLoggedIn(false);
    };

    const handleLogin = async (username, password) => {
        try {
            // Attempt login
            const loginResponse = await authService.login(username, password);
    
            // Assuming the response includes the user ID or token that we can use to fetch the user
            const userId = loginResponse.userId;  // Adjust based on actual API response
    
            // Fetch user data after login
            const userData = await userService.getUser(userId);
    
            // Set the current user in state
            setCurrentUser(userData);
            setIsLoggedIn(true);
            setIsLoginOpen(false);
        } catch (error) {
            console.error('Error logging in:', error);
        }
    };

    const openLoginDropdown = () => {
        setIsLoginOpen(true);  // Correctly sets the state to open the dropdown
    };

    return (
        <div className="home-page">
            <TopBanner
                isLoggedIn={isLoggedIn}
                handleLogout={handleLogout}
                openLoginDropdown={openLoginDropdown}  // Correctly pass the function here
            />
            <CategoryList onCategoryClick={handleCategoryClick} />
            
            {/* Conditionally render the 'Back to Home' button when a category is selected */}
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
                    currentUser={currentUser}  // Pass the currentUser here
                />
            )}
            {isLoginOpen && (
                <div className="dropdown-overlay">
                    <LoginDropDown
                        closeModal={() => setIsLoginOpen(false)}
                        handleLogin={handleLogin}  // Pass the handleLogin function to LoginDropDown
                        isDarkMode={false}
                    />
                </div>
            )}
        </div>
    );
};

export default HomePage;
