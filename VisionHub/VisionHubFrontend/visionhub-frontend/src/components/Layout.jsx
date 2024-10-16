// src/components/Layout.jsx
import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import CategoryList from './CategoryList.jsx';
import LoginDropdown from './LoginDropDown.jsx';
import axios from 'axios';

const Layout = () => {
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const [isDarkMode, setIsDarkMode] = useState(false);
    const [isDropdownOpen, setIsDropdownOpen] = useState(false); // State for dropdown

    useEffect(() => {
        const token = localStorage.getItem('token');
        setIsLoggedIn(!!token);
        const darkModePreference = localStorage.getItem('darkMode') === 'true';
        setIsDarkMode(darkModePreference);
    }, []);

    const toggleDarkMode = () => {
        setIsDarkMode(!isDarkMode);
        localStorage.setItem('darkMode', !isDarkMode);
    };

    const handleLogout = () => {
        localStorage.removeItem('token');
        setIsLoggedIn(false);
    };

    const toggleDropdown = () => {
        setIsDropdownOpen(!isDropdownOpen); // Toggle dropdown state
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
                            <button className="options-button" onClick={toggleDropdown}>
                                Options {isDropdownOpen ? '▲' : '▼'} {/* Arrow indicator */}
                            </button>
                            {isDropdownOpen && (
                                <div className="dropdown-content">
                                    <Link to="/profile">Profile</Link>
                                    <button onClick={handleLogout}>Logout</button>
                                </div>
                            )}
                        </div>
                    ) : (
                        <LoginDropdown />
                    )}
                </div>
                <div className="dark-mode-toggle">
                    <button onClick={toggleDarkMode}>
                        {isDarkMode ? 'Light Mode' : 'Dark Mode'}
                    </button>
                </div>
            </div>
            <div className="main-content">
                <CategoryList />
            </div>
        </div>
    );
};

export default Layout;
