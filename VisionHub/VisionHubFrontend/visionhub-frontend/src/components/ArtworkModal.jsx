import React from 'react';
import CommentSection from './CommentSection.jsx';

const ArtworkModal = ({ artwork, comments, closeModal, handleCommentSubmit, commentText, setCommentText, isDarkMode }) => {
    return (
        <div className={`artwork-modal ${isDarkMode ? 'dark-mode' : ''}`}>
            <div className={`modal-content ${isDarkMode ? 'dark-mode' : ''}`}>
                <button className={`close-modal ${isDarkMode ? 'dark-mode' : ''}`} onClick={closeModal}>X</button>
                <h2>{artwork.title}</h2>
                <img src={artwork.imageUrl} alt={artwork.title} />
                <div className="artwork-fullsize">
                    <div className="artwork-details">
                        <p>{artwork.description}</p>
                    </div>
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
