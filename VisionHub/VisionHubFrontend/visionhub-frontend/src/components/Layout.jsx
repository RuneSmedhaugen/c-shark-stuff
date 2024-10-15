// src/components/Layout.jsx
import React from 'react';
import { Link } from 'react-router-dom';
import CategoryList from './CategoryList.jsx';
import LoginDropdown from './LoginDropDown.jsx';

const Layout = ({ children }) => {
    return (
        <div className="app">
            {/* Top Banner */}
            <header className="top-banner">
                <Link to="/" className="logo">
                    VisionHub
                </Link>

                <div className="search-bar">
                    <input type="text" placeholder="Search..." />
                    <button>Search</button>
                </div>
                <div className="header-buttons">
                    <Link to="/upload">
                        <button className="upload-btn">Upload Artwork</button>
                    </Link>
                    <LoginDropdown />
                    <button className="dark-mode-btn">Dark Mode</button>
                </div>
            </header>

            {/* Horizontal Categories */}
            <nav className="categories-banner">
                <CategoryList />
            </nav>

            {/* Main Content */}
            <main className="content">{children}</main>
        </div>
    );
};

export default Layout;
