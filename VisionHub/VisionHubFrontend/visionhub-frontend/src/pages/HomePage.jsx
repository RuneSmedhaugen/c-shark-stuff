import React from 'react';
import Layout from '../components/Layout.jsx'; 
import FeaturedArtworks from '../components/FeaturedArtwork.jsx';

const HomePage = () => {
    return (
        <Layout>
            <main className="featured-artworks">
                <FeaturedArtworks />
            </main>
        </Layout>
    );
};

export default HomePage;
