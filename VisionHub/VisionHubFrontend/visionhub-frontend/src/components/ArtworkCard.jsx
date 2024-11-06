import React from 'react';

const ArtworkCard = ({ artwork, onClick, isDarkMode }) => {
    return (
        <div className={`artwork-card ${isDarkMode ? 'dark-mode' : ''}`} onClick={() => onClick(artwork)}>
            <div className="artwork-image-container">
                <img className="artwork-image" src={artwork.imageUrl} alt={artwork.title} />
            </div>
            <div className="artwork-info">
                <h3 className={`artwork-title ${isDarkMode ? 'dark-mode' : ''}`}>{artwork.title}</h3>
                <p className={`artwork-description ${isDarkMode ? 'dark-mode' : ''}`}>{artwork.description}</p>
            </div>
        </div>
    );
};

export default ArtworkCard;
