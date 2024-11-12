import React, { useState } from 'react';
import { authService } from '../services/authService';
import { useNavigate } from 'react-router-dom';
import '../styles/LoginDropDown.css';

const LoginDropDown = ({ closeModal, setIsLoggedIn, isDarkMode }) => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const navigate = useNavigate();

    const handleLogin = async () => {
        if (username && password) {
            try {
                const response = await authService.login(username, password);
                setIsLoggedIn(true);
                closeModal();
            } catch (error) {
                setError('Invalid login credentials');
            }
        } else {
            setError('Please enter both username and password');
        }
    };

    const handleRegisterClick = () => {
        closeModal();
        navigate('/register');
    };

    return (
        <div className={`dropdown-window ${isDarkMode ? 'dark-mode' : ''}`}>
            <button className="close-login" onClick={closeModal}>X</button>
            <h2>Login</h2>
            {error && <p className="error-message">{error}</p>}
            <form>
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
                <button type="button" onClick={handleLogin}>Login</button>

                <button onClick={handleRegisterClick} className="register-link">
                Don't have an account? Register here.
            </button>
            </form>
        </div>
    );
};

export default LoginDropDown;
