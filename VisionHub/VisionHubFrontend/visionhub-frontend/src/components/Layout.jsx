import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import CategoryList from './CategoryList.jsx';
import LoginDropdown from './LoginDropDown.jsx';
import { artworkService } from '../services/apiService'; 

const Layout = () => {
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const [artworks, setArtworks] = useState([]);
    const [selectedCategory, setSelectedCategory] = useState(null);
    const [error, setError] = useState('');
    const [isDarkMode, setIsDarkMode] = useState(false);

    // Check if the user is logged in
    useEffect(() => {
        const token = localStorage.getItem('token');
        setIsLoggedIn(!!token);
    }, []);

    // Fetch featured artworks when the component mounts
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

    // Fetch art based on selected category
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

    const handleLogout = () => {
        localStorage.removeItem('token');
        setIsLoggedIn(false);
        setSelectedCategory(null);
        setArtworks([]);
    };

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
                                <button onClick={handleLogout}>Logout</button>
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
                                <li key={artwork.id}>
                                    <img src={artwork.imageUrl} alt={artwork.title} />
                                    <p>{artwork.title}</p>
                                </li>
                            ))}
                        </ul>
                    ) : (
                        <p>No artworks available.</p>
                    )}
                </div>

                {selectedCategory && (
                    <button className="back-to-home" onClick={handleBackToHome}>Back to Homepage</button>
                )}
            </div>
        </div>
    );
};

export default Layout;
