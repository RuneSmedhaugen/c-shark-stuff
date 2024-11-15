import React from 'react';
import CommentSection from './CommentSection.jsx';
import { commentService } from '../services/apiService.js';

const ArtworkModal = ({ artwork, comments, closeModal, commentText, setCommentText, isDarkMode, currentUser }) => {
    // Ensure currentUser is available and logged in
    if (!currentUser) {
        console.error("currentUser is undefined");
        return (
            <div className={`artwork-modal ${isDarkMode ? 'dark-mode' : ''}`} onClick={closeModal}>
                <div className={`modal-content ${isDarkMode ? 'dark-mode' : ''}`} onClick={(e) => e.stopPropagation()}>
                    <p>Please log in to view artwork.</p>
                </div>
            </div>
        );
    }

    // Map comments to extract the necessary data
    const cleanedComments = comments.map(comment => ({
        id: comment.id,
        username: comment.username.userName,  // Extract just the username
        commentText: comment.commentText,
        commentDate: comment.commentDate
    }));

    const handleCommentSubmit = async () => {
        if (!commentText.trim()) {
            console.warn("Comment text is empty");
            return; // Prevent submission if the comment is empty
        }

        const commentData = {
            artworkID: artwork.id,
            userID: currentUser.id,  // Ensure currentUser is defined before using its properties
            commentText: commentText,
            commentDate: new Date().toISOString() // Ensure the date is in ISO format
        };

        try {
            const result = await commentService.addComment(commentData);
            console.log('Comment submitted:', result);
            setCommentText(''); // Clear comment field after submission
        } catch (error) {
            console.error('Error submitting comment:', error);
        }
    };

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
                        src={`https://localhost:7213/${artwork.imagePath}`}
                        alt={artwork.title}
                        className="artwork-modal-image"
                    />
                </div>
                <div className="artwork-details">
                    <p>{artwork.description}</p>
                </div>
                <CommentSection
                    comments={cleanedComments}
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
