import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import logo from '../img/visionhub_logo.png';
import SearchField from './CombinedSearchField.jsx';
import '../styles/main.css';

const TopBanner = ({ isLoggedIn, handleLogout, openLoginDropdown }) => {
    const [isDarkMode, setIsDarkMode] = useState(false);
  
    useEffect(() => {
      const savedDarkMode = localStorage.getItem('isDarkMode') === 'true';
      setIsDarkMode(savedDarkMode);
      if (savedDarkMode) {
        document.body.classList.add('dark-mode');
      } else {
        document.body.classList.remove('dark-mode');
      }
    }, []);
  
    const toggleDarkMode = () => {
      setIsDarkMode((prev) => {
        const newDarkMode = !prev;
        localStorage.setItem('isDarkMode', newDarkMode);
        if (newDarkMode) {
          document.body.classList.add('dark-mode');
        } else {
          document.body.classList.remove('dark-mode');
        }
        return newDarkMode;
      });
    };
  
    return (
      <div className="top-banner">
        <Link to="/" className="logo">
          <img src={logo} alt="VisionHub Logo" className="logo-image" />
        </Link>
        <div className="search-section">
          <SearchField />
        </div>
        <div className="auth-section">
          {isLoggedIn ? (
            <div className="options-dropdown">
              <button className="options-button" onClick={handleLogout}>Logout</button>
            </div>
          ) : (
            <button className="login-button" onClick={openLoginDropdown}>Log in</button>  // Using the function passed as a prop
          )}
          <button className="dark-mode-toggle" onClick={toggleDarkMode}>
            {isDarkMode ? 'Light Mode' : 'Dark Mode'}
          </button>
        </div>
      </div>
    );
  };
  
  export default TopBanner;
