import React from 'react';
import CommentSection from './CommentSection.jsx';

const ArtworkModal = ({ artwork, comments, closeModal, handleCommentSubmit, commentText, setCommentText, isDarkMode }) => {
   
    const imageUrl = `https://localhost:7213/${artwork.imagePath}`;
    return (
        <div
            className={`artwork-modal ${isDarkMode ? 'dark-mode' : ''}`}
            onClick={closeModal}
        >
            <div
                className={`modal-content ${isDarkMode ? 'dark-mode' : ''}`}
                onClick={(e) => e.stopPropagation()}
            >
                <button
                    className={`close-modal ${isDarkMode ? 'dark-mode' : ''}`}
                    onClick={closeModal}
                >
                    X
                </button>
                <h2 className="artwork-modal-title">{artwork.title}</h2>
                <div className="artwork-image-container">
                    <img
                        src={imageUrl}
                        alt={artwork.title}
                        className="artwork-modal-image"
                    />
                </div>
                <div className="artwork-details">
                    <p>{artwork.description}</p>
                </div>
                <CommentSection
                    comments={comments}
                    commentText={commentText}
                    setCommentText={setCommentText}
                    handleCommentSubmit={handleCommentSubmit}
                    isDarkMode={isDarkMode}
                />
            </div>
        </div>
    );
};

export default ArtworkModal;
