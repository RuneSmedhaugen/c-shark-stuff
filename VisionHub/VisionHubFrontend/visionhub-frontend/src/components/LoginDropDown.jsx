import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { authService } from '../services/authService';

const LoginDropdown = () => {
    const [isDropdownOpen, setIsDropdownOpen] = useState(false);
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState('');

    const toggleDropdown = () => {
        setIsDropdownOpen(!isDropdownOpen);
    };

    const handleLogin = async () => {
        try {
            const userData = await authService.login(username, password);
            
            localStorage.setItem('userId', userData.id); 
            alert('Login successful!');
            
            setIsDropdownOpen(false);
        
            setUsername('');
            setPassword('');
        } catch (error) {
            setErrorMessage('Invalid username or password');
            console.error('Error logging in:', error);
        }
    };

    return (
        <div className="login-dropdown">
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
                    <button onClick={handleLogin}>Login here</button>
                    {errorMessage && <p className="error-message">{errorMessage}</p>}
                    <Link to="/register">
                        <button>Register</button>
                    </Link>
                </div>
            )}
        </div>
    );
};

export default LoginDropdown;
