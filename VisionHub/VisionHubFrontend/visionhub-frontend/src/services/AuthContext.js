import React, { createContext, useContext, useState, useEffect } from 'react';
import { authService } from '../services/authService';
import { userService } from '../services/apiService';

const AuthContext = createContext();

export const useAuth = () => useContext(AuthContext);

const AuthProvider = ({ children }) => {
    const [currentUser, setCurrentUser] = useState(null);
    const [isLoggedIn, setIsLoggedIn] = useState(false);

    const login = async (username, password) => {
        try {
            const loginResponse = await authService.login(username, password);
            const userId = loginResponse?.userId || localStorage.getItem('userid');
            const userData = await userService.getUser(userId);
            setCurrentUser(userData);
            setIsLoggedIn(true);
            return true; // Login successful
        } catch (error) {
            console.error('Login failed:', error);
            return false; // Login failed
        }
    };

    const logout = () => {
        authService.logout();
        setCurrentUser(null);
        setIsLoggedIn(false);
    };

    useEffect(() => {
        const token = authService.getToken();
        const userId = localStorage.getItem('userid');

        if (token && userId) {
            userService.getUser(userId)
                .then((userData) => {
                    setCurrentUser(userData);
                    setIsLoggedIn(true);
                })
                .catch((error) => console.error('Failed to fetch user data:', error));
        }
    }, []);

    return (
        <AuthContext.Provider value={{ currentUser, isLoggedIn, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
};

export default AuthProvider;
