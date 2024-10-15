import React, { useEffect, useState } from 'react';
import axios from 'axios';

const ArtworkInfo = () => {
    const [artworks, setArtworks] = useState([]); // State to hold artworks
    const [error, setError] = useState(null); // State to handle errors

    useEffect(() => {
        const fetchArtworks = async () => {
            try {
                const artworkResponse = await axios.get(`https://localhost:7213/api/artwork/all`);
                setArtworks(artworkResponse.data); // Assume this returns an array of artworks
            } catch (err) {
                console.error(err);
                setError('Failed to fetch artwork data.');
            }
        };

        fetchArtworks(); // Call the function when the component mounts
    }, []); // Empty array ensures the effect runs only once on component mount

    return (
        <div className="artwork-info">
            {error && <p>{error}</p>}
            {!error && artworks.length === 0 && <p>Loading artwork data...</p>}
            {artworks.length > 0 && (
                <div>
                    <h2>Artworks</h2>
                    {artworks.map((artwork) => (
                        <div key={artwork.artId}>
                            <p><strong>ArtID:</strong> {artwork.artId}</p>
                            <p><strong>UserID:</strong> {artwork.userId}</p>
                            <p><strong>Title:</strong> {artwork.title}</p>
                            <p><strong>Description:</strong> {artwork.description}</p>
                            <p><strong>Upload Date:</strong> {artwork.uploadDate}</p>
                            <p><strong>Image URL:</strong> {artwork.imageUrl}</p>
                            <p><strong>CategoryID:</strong> {artwork.categoryId}</p>
                            <img src={artwork.imageUrl} alt={artwork.title} style={{ width: '200px', height: 'auto' }} />
                            <hr /> {/* To separate each artwork */}
                        </div>
                    ))}
                </div>
            )}
        </div>
    );
};

export default ArtworkInfo;
