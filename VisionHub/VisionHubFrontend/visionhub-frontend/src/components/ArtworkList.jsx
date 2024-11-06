import React from 'react';
import ArtworkCard from './ArtworkCard.jsx';

const ArtworkList = ({ artworks, handleArtworkClick, isDarkMode }) => {
    if (artworks.length === 0) return <p>No artworks available.</p>;

    return (
        <ul>
            {artworks.map((artwork) => (
                <ArtworkCard
                    key={artwork.id}
                    artwork={artwork}
                    onClick={handleArtworkClick}
                    isDarkMode={isDarkMode}
                />
            ))}
        </ul>
    );
};

export default ArtworkList;
