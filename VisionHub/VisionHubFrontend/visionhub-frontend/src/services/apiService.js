import axios from 'axios';

// Set the base URL for your API requests
const API_BASE_URL = 'https://localhost:7213/api'; 

// Function to handle any GET request
const get = async (endpoint) => {
    try {
        const response = await axios.get(`${API_BASE_URL}${endpoint}`);
        return response.data;
    } catch (error) {
        console.error('Error in GET request:', error);
        throw error;
    }
};

// Function to handle any POST request
const post = async (endpoint, data) => {
    try {
        const response = await axios.post(`${API_BASE_URL}${endpoint}`, data);
        return response.data;
    } catch (error) {
        console.error('Error in POST request:', error);
        throw error;
    }
};

// Function to handle any PUT request
const put = async (endpoint, data) => {
    try {
        const response = await axios.put(`${API_BASE_URL}${endpoint}`, data);
        return response.data;
    } catch (error) {
        console.error('Error in PUT request:', error);
        throw error;
    }
};

// Function to handle any DELETE request
const remove = async (endpoint) => {
    try {
        const response = await axios.delete(`${API_BASE_URL}${endpoint}`);
        return response.data;
    } catch (error) {
        console.error('Error in DELETE request:', error);
        throw error;
    }
};

// Users API
export const userService = {
    registerUser: (userData) => post('/user/register', userData),
    updateUser: (userData) => put('/user/update', userData),
    deleteUser: (userId) => remove(`/user/${userId}`),
    getUser: (userId) => get(`/user/${userId}`),
    getAllUsers: () => get('/user/all'),
};

// Comments API
export const commentService = {
    addComment: (commentData) => post('/comment/add', commentData),
    getAllComments: () => get('/comment/all'),
    getCommentsByArtwork: (artworkId) => get(`/comment/artwork/${artworkId}`),
    getCommentsByUser: (userId) => get(`/comment/user/${userId}`),
    updateComment: (commentId, commentData) => put(`/comment/update/${commentId}`, commentData),
    deleteComment: (commentId) => remove(`/comment/delete/${commentId}`),
};

// Artworks API
export const artworkService = {
    addArtwork: (artworkData) => post('/artwork/add', artworkData),
    getArtwork: (artworkId) => get(`/artwork/${artworkId}`),
    getAllArtworks: () => get('/artwork'),
    updateArtwork: (artworkId, artworkData) => put(`/artwork/update/${artworkId}`, artworkData),
    deleteArtwork: (artworkId) => remove(`/artwork/delete/${artworkId}`),
};

// Categories API
export const categoryService = {
    addCategory: (categoryData) => post('/category/add', categoryData),
    getCategory: (categoryId) => get(`/category/${categoryId}`),
    getAllCategories: () => get('/category'),
    updateCategory: (categoryId, categoryData) => put(`/category/update/${categoryId}`, categoryData),
    deleteCategory: (categoryId) => remove(`/category/delete/${categoryId}`),
};
