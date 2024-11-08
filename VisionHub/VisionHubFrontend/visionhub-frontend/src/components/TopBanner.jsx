import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { authService } from '../services/authService.js';
import LoginDropdown from './LoginDropDown.jsx';

const TopBanner = ({ isLoggedIn, setIsLoggedIn, toggleDarkMode, isDarkMode }) => {
    const [showDropdown, setShowDropdown] = useState(false);

    const handleLogout = () => {
        authService.logout();
        setIsLoggedIn(false);
        setShowDropdown(false);
        window.location.reload();
    };

    return (
        <div className="top-banner">
            <Link to="/" className="logo">VisionHub</Link>
            <div className="search-section">
                <input type="text" placeholder="Search artwork..." />
                <button>Search</button>
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
                    <LoginDropdown setIsLoggedIn={setIsLoggedIn} />
                )}
                <button className="dark-mode-toggle" onClick={toggleDarkMode}>
                    {isDarkMode ? 'Light Mode' : 'Dark Mode'}
                </button>
            </div>
        </div>
    );
};

export default TopBanner;
