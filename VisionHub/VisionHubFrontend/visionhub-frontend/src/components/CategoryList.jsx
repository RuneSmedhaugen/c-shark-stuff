import React, { useEffect, useState } from 'react';
import { categoryService } from '../services/apiService'; // Adjust the import path as necessary

const CategoryList = () => {
    const [categories, setCategories] = useState([]); // State to hold the categories
    const [error, setError] = useState(''); // State to hold error messages

    useEffect(() => {
        const fetchCategories = async () => {
            try {
                const data = await categoryService.getAllCategories(); // Fetch categories from the API
                setCategories(data); // Update the state with the fetched categories
            } catch (error) {
                setError('Failed to load categories.'); // Handle errors
                console.error('Error fetching categories:', error);
            }
        };

        fetchCategories(); // Call the fetch function
    }, []); // Empty dependency array means this runs once when the component mounts

    return (
        <div className="category-list">
            {error && <p style={{ color: 'red' }}>{error}</p>} {/* Show error message if any */}
            <ul className="categories">
                {categories.map((category, index) => (
                    <li key={index} className="category-item">
                        {category.name} {/* Assuming each category has a 'name' property */}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default CategoryList;
