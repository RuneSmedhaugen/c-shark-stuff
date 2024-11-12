import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { authService } from '../services/authService.js';
import LoginDropDown from './LoginDropDown.jsx';
import logo from '../img/visionhub_logo.png';
import SearchField from './SearchField';  // Import the new SearchField component
import '../styles/main.css';

const TopBanner = ({ isLoggedIn, setIsLoggedIn }) => {
    const [showLoginModal, setShowLoginModal] = useState(false);
    const [showDropdown, setShowDropdown] = useState(false);
    const [isDarkMode, setIsDarkMode] = useState(false);

    // Check if dark mode preference is stored in localStorage
    useEffect(() => {
        const savedDarkMode = localStorage.getItem('isDarkMode') === 'true';
        setIsDarkMode(savedDarkMode);
        if (savedDarkMode) {
            document.body.classList.add('dark-mode');
        } else {
            document.body.classList.remove('dark-mode');
        }
    }, []);

    // Function to toggle dark mode
    const toggleDarkMode = () => {
        setIsDarkMode((prev) => {
            const newDarkMode = !prev;
            localStorage.setItem('isDarkMode', newDarkMode); // Store preference in localStorage
            if (newDarkMode) {
                document.body.classList.add('dark-mode');
            } else {
                document.body.classList.remove('dark-mode');
            }
            return newDarkMode;
        });
    };

    const handleLogout = () => {
        authService.logout();
        setIsLoggedIn(false);
        setShowDropdown(false);
    };

    const openLoginModal = () => setShowLoginModal(true);
    const closeLoginModal = () => setShowLoginModal(false);

    return (
        <div className="top-banner">
            <Link to="/" className="logo">
                <img src={logo} alt="VisionHub Logo" className="logo-image" />
            </Link>
            <div className="search-section">
                <SearchField />  {/* Add the SearchField component */}
            </div>
            <div className="auth-section">
                {isLoggedIn ? (
                    <div className="options-dropdown">
                        <button 
                            className="options-button" 
                            onClick={() => setShowDropdown((prev) => !prev)}
                        >
                            Options
                        </button>
                        {showDropdown && (
                            <div className="dropdown-content">
                                <Link to="/profile" onClick={() => setShowDropdown(false)}>Profile</Link>
                                <button onClick={handleLogout}>Logout</button>
                            </div>
                        )}
                    </div>
                ) : (
                    <button className="login-button" onClick={openLoginModal}>Login</button>
                )}
                <button className="dark-mode-toggle" onClick={toggleDarkMode}>
                    {isDarkMode ? 'Light Mode' : 'Dark Mode'}
                </button>
                {showLoginModal && (
                    <LoginDropDown 
                        setIsLoggedIn={setIsLoggedIn} 
                        closeModal={closeLoginModal}
                        isDarkMode={isDarkMode}
                    />
                )}
            </div>
        </div>
    );
};

export default TopBanner;
