import React, { useState } from 'react';
import { userService } from '../services/apiService';

function LoginDropDown() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState(''); // For showing error messages

    const handleLogin = async () => {
        console.log('Login button clicked'); // Step 1: Check if button is working
        try {
            const response = await userService.loginUser({ username, password });
            console.log('Login response:', response); // Step 2: Check API response

            if (response && response.token) {
                localStorage.setItem('token', response.token); // Save token to localStorage
                // TODO: Update the UI to show the Options button instead of Login
                setErrorMessage(''); // Clear error if login is successful
            } else {
                setErrorMessage('Login failed: Invalid response from server'); // Show a user-friendly error
            }
        } catch (error) {
            console.error('Login failed:', error); // Step 3: Check for error
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
