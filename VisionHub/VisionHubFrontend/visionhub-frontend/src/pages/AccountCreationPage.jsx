import React, { useState } from 'react';
import axios from 'axios';
import Layout from '../components/Layout.jsx'; 

const AccountCreationPage = () => {
    const [formData, setFormData] = useState({
        username: '',
        email: '',
        password: '',
        confirmPassword: '',
        biography: '',
        birthdate: '',
        name: ''
    });

    const [error, setError] = useState('');
    const [successMessage, setSuccessMessage] = useState('');

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
        console.log(`Field changed: ${e.target.name}, New value: ${e.target.value}`);
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        const { username, email, password, biography, birthdate, name } = formData;

        const userData = {
            UserName: username,
            Email: email,
            Name: name,
            Password: password, 
            Biography: biography,
            BirthDate: birthdate,
        };

        try {
            const response = await axios.post('https://localhost:7213/api/user/register', userData, {
                headers: {
                    'Content-Type': 'application/json',
                },
            });
            console.log('Account created:', response.data);
            setSuccessMessage('Account created successfully!');
            setError(''); 
        } catch (error) {
            console.error('Error creating account:', error);
            setError('Error creating account: ' + (error.response?.data.message || 'Something went wrong'));
        }
    };

    return (
        <Layout>
            <div className="account-creation-page">
                <h2>Create an Account</h2>
                {error && <p style={{ color: 'red' }}>{error}</p>}
                {successMessage && <p style={{ color: 'green' }}>{successMessage}</p>}
                <form onSubmit={handleSubmit}>
                    <label>
                        Username:
                        <input
                            type="text"
                            name="username"
                            value={formData.username}
                            onChange={handleChange}
                            required
                        />
                    </label>
                    <label>
                        Email:
                        <input
                            type="email"
                            name="email"
                            value={formData.email}
                            onChange={handleChange}
                            required
                        />
                    </label>
                    <label>
                        Password:
                        <input
                            type="password"
                            name="password"
                            value={formData.password}
                            onChange={handleChange}
                            required
                        />
                    </label>
                    <label>
                        Confirm Password:
                        <input
                            type="password"
                            name="confirmPassword"
                            value={formData.confirmPassword}
                            onChange={handleChange}
                            required
                        />
                    </label>
                    <label>
                        Biography:
                        <textarea
                            name="biography"
                            value={formData.biography}
                            onChange={handleChange}
                            required
                        />
                    </label>
                    <label>
                        Birthdate:
                        <input
                            type="date"
                            name="birthdate"
                            value={formData.birthdate}
                            onChange={handleChange}
                            required
                        />
                    </label>
                    <label>
                        Name:
                        <input
                            type="text"
                            name="name"
                            value={formData.name}
                            onChange={handleChange}
                            required
                        />
                    </label>
                    <button type="submit">Register</button>
                </form>
            </div>
        </Layout>
    );
};

export default AccountCreationPage;
