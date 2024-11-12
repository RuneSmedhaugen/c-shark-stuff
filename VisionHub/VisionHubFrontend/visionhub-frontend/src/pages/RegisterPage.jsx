import React, { useState } from 'react';
import { userService } from '../services/apiService';
import { useNavigate } from 'react-router-dom';
import TopBanner from '../components/TopBanner';

const RegisterPage = () => {
    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const [success, setSuccess] = useState(false);
    const navigate = useNavigate();

    const handleRegister = async (event) => {
        event.preventDefault();
        const userData = { username, email, password };

        try {
            await userService.registerUser(userData);
            setSuccess(true);
            navigate('/');
        } catch (err) {
            setError('Registration failed. Please try again.');
            console.error('Error during registration:', err);
        }
    };

    return (
        <div className="register-page">
            <TopBanner />
            <div className="register-container">
                <h2>Register</h2>
                {error && <p className="error">{error}</p>}
                {success && <p className="success">Registration successful! Redirecting...</p>}
                <form onSubmit={handleRegister}>
                    <input
                        type="text"
                        placeholder="Username"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                        required
                    />
                    <input
                        type="email"
                        placeholder="Email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                    <input
                        type="password"
                        placeholder="Password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                    <button type="submit">Register</button>
                </form>
            </div>
        </div>

    );
};

export default RegisterPage;
