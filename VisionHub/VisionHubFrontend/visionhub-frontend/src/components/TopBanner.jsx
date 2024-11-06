import React from 'react';
import { Link } from 'react-router-dom';
import { authService } from '../services/authService.js';
import LoginDropdown from './LoginDropDown.jsx';

const TopBanner = ({ isLoggedIn, toggleDarkMode, isDarkMode }) => {
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
                        <button className="options-button">Options</button>
                        <div className="dropdown-content">
                            <Link to="/profile">Profile</Link>
                            <button onClick={authService.logout()}>Logout</button>
                        </div>
                    </div>
                ) : (
                    <LoginDropdown />
                )}
                <button className='dark-mode-toggle' onClick={toggleDarkMode}>
                    {isDarkMode ? 'Light Mode' : 'Dark Mode'}
                </button>
            </div>
        </div>
    );
};

export default TopBanner;
