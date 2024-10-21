import React, { useState, useEffect, useRef } from 'react';
import { Link } from 'react-router-dom';
import { authService } from '../services/authService';

const LoginDropdown = () => {
    const [isDropdownOpen, setIsDropdownOpen] = useState(false);
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState('');
    const dropdownRef = useRef(null);  // Create a reference for the dropdown

    // Check if the user is already logged in
    useEffect(() => {
        const userId = localStorage.getItem('userId');
        setIsLoggedIn(!!userId);
    }, []);

    const toggleDropdown = () => {
        setIsDropdownOpen(!isDropdownOpen);
    };

    const handleLogin = async () => {
        try {
            const userData = await authService.login(username, password);
            localStorage.setItem('userId', userData.id); // Store user ID or token
            alert('Login successful!');
            setIsLoggedIn(true);
            setIsDropdownOpen(false);
            setUsername('');
            setPassword('');
        } catch (error) {
            setErrorMessage('Invalid username or password');
            console.error('Error logging in:', error);
        }
    };

    const handleLogout = () => {
        localStorage.removeItem('userId'); // Clear user ID/token
        setIsLoggedIn(false);
        setIsDropdownOpen(false);
        alert('Logged out successfully!');
    };

    // Close the dropdown if clicking outside of it
    useEffect(() => {
        const handleClickOutside = (event) => {
            if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
                setIsDropdownOpen(false);
            }
        };

        if (isDropdownOpen) {
            document.addEventListener('mousedown', handleClickOutside);
        } else {
            document.removeEventListener('mousedown', handleClickOutside);
        }

        return () => {
            document.removeEventListener('mousedown', handleClickOutside);
        };
    }, [isDropdownOpen]);

    return (
        <div className="login-dropdown">
            {isLoggedIn ? (
                <div>
                    <button className="login-button" onClick={toggleDropdown}>
                        Options
                    </button>
                    {isDropdownOpen && (
                        <div className="dropdown-overlay">
                            <div className="dropdown-window" ref={dropdownRef}>
                                <Link to="/profile">
                                    <button className="login-button">Profile</button>
                                </Link>
                                <button className="login-button" onClick={handleLogout}>Logout</button>
                            </div>
                        </div>
                    )}
                </div>
            ) : (
                <div>
                    <button className="login-button" onClick={toggleDropdown}>
                        Login
                    </button>
                    {isDropdownOpen && (
                        <div className="dropdown-overlay">
                            <div className="dropdown-window" ref={dropdownRef}>
                                <input
                                    type="text"
                                    placeholder="Username"
                                    value={username}
                                    onChange={(e) => setUsername(e.target.value)}
                                />
                                <input
                                    type="password"
                                    placeholder="Password"
                                    value={password}
                                    onChange={(e) => setPassword(e.target.value)}
                                />
                                <button className="login-button" onClick={handleLogin}>Login</button>
                                {errorMessage && <p className="error-message">{errorMessage}</p>}
                                <Link to="/register">
                                    <button className="login-button">Register</button>
                                </Link>
                            </div>
                        </div>
                    )}
                </div>
            )}
        </div>
    );
};

export default LoginDropdown;
