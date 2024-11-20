import React, { useEffect } from 'react';
import { Link } from 'react-router-dom';
import logo from '../img/visionhub_logo.png';
import SearchField from './CombinedSearchField.jsx';
import '../styles/main.css';

const TopBanner = ({ isLoggedIn, handleLogout, openLoginDropdown, handleProfile, isDarkMode, setIsDarkMode }) => {
  useEffect(() => {
    if (isDarkMode) {
      document.body.classList.add('dark-mode');
    } else {
      document.body.classList.remove('dark-mode');
    }
  }, [isDarkMode]);

  const toggleDarkMode = () => {
    const newDarkMode = !isDarkMode;
    setIsDarkMode(newDarkMode);
    localStorage.setItem('isDarkMode', newDarkMode);
  };

  return (
    <div className={`top-banner ${isDarkMode ? 'dark' : ''}`}>
      <Link to="/" className="logo">
        <img src={logo} alt="VisionHub Logo" className="logo-image" />
      </Link>
      <div className="search-section">
        <SearchField />
      </div>
      <div className="auth-section">
        {isLoggedIn ? (
          <div className="options-dropdown">
            <button className="profile-button" onClick={handleProfile}>Profile</button>
            <button className="logout-button" onClick={handleLogout}>Logout</button>
          </div>
        ) : (
          <button className="login-button" onClick={openLoginDropdown}>Log in</button>
        )}
        <button className="dark-mode-toggle" onClick={toggleDarkMode}>
          {isDarkMode ? 'Light Mode' : 'Dark Mode'}
        </button>
      </div>
    </div>
  );
};

export default TopBanner;
