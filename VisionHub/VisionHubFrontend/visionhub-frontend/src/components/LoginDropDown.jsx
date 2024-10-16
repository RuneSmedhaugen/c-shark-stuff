import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { authService } from '../services/authService';

const LoginDropdown = () => {
    const [isDropdownOpen, setIsDropdownOpen] = useState(false);
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState('');

    // Check if the user is already logged in by looking for a token or userId
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
            
            setIsLoggedIn(true); // Set login state
            setIsDropdownOpen(false); // Close the dropdown
            setUsername('');
            setPassword('');
        } catch (error) {
            setErrorMessage('Invalid username or password');
            console.error('Error logging in:', error);
        }
    };

    const handleLogout = () => {
        localStorage.removeItem('userId'); // Clear user ID/token
        setIsLoggedIn(false); // Set logout state
        setIsDropdownOpen(false); // Close the dropdown
        alert('Logged out successfully!');
    };

    return (
        <div className="login-dropdown">
            {isLoggedIn ? (
                <div className="options-dropdown">
                    <button className="options-btn" onClick={toggleDropdown}>
                        Options
                    </button>
                    {isDropdownOpen && (
                        <div className="dropdown-menu">
                            <Link to="/profile">
                                <button>Profile</button>
                            </Link>
                            <button onClick={handleLogout}>Logout</button>
                        </div>
                    )}
                </div>
            ) : (
                <div>
                    <button className="login-btn" onClick={toggleDropdown}>
                        Login
                    </button>
                    {isDropdownOpen && (
                        <div className="dropdown-menu">
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
                            <button onClick={handleLogin}>Login</button>
                            {errorMessage && <p className="error-message">{errorMessage}</p>}
                            <Link to="/register">
                                <button>Register</button>
                            </Link>
                        </div>
                    )}
                </div>
            )}
        </div>
    );
};

export default LoginDropdown;
