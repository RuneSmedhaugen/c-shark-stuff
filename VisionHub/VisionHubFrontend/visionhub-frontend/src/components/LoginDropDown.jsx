import React, { useState } from 'react';
import { userService } from '../services/apiService';

function LoginDropDown({ setIsLoggedIn }) {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState('');

    const handleLogin = async () => {
        try {
            const response = await userService.loginUser({ username, password });

            if (response && response.token) {
                localStorage.setItem('token', response.token);
                setIsLoggedIn(true);
                window.location.reload();
                setErrorMessage('');
            } else {
                setErrorMessage('Login failed: Invalid response from server');
            }
        } catch (error) {
            console.error('Login failed:', error);
            setErrorMessage('Login failed: Invalid username or password');
        }
    };

    return (
        <div className="login-dropdown">
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
            <div className="auth-section">
                <button className="login-button" onClick={handleLogin}>Login</button>
            </div>
            {errorMessage && <p style={{ color: 'red' }}>{errorMessage}</p>}
        </div>
    );
}

export default LoginDropDown;
