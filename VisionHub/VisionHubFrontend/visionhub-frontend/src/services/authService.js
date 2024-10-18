import axios from 'axios';

const API_BASE_URL = 'https://localhost:7213/api';

export const authService = {
    // Login function that handles authentication
    login: async (username, password) => {
        try {
            // Send login request to the backend
            const response = await axios.post(`${API_BASE_URL}/user/login`, {
                username,
                password,
            });

            const { token, userId } = response.data;

            localStorage.setItem('authToken', token);
            localStorage.setItem('userId', userId);

            return response.data;
        } catch (error) {
            console.error('Error logging in:', error);
            throw error;
        }
    },

    // Function to check if the user is authenticated by checking for a token
    isAuthenticated: () => {
        const token = localStorage.getItem('authToken');
        return !!token;
    },

    // Logout function to clear local storage and log out the user
    logout: () => {
        localStorage.removeItem('authToken');
        localStorage.removeItem('userId');
    },

    // Retrieve the stored token
    getToken: () => {
        return localStorage.getItem('authToken');
    },

    // Retrieve the logged-in user ID
    getUserId: () => {
        return localStorage.getItem('userId');
    }
};
