import React from 'react';
import CommentSection from './CommentSection.jsx';
import { commentService } from '../services/apiService.js';

const ArtworkModal = ({ artwork, comments, closeModal, commentText, setCommentText, isDarkMode, currentUser }) => {
    const cleanedComments = comments.map(comment => ({
        id: comment.id,
        username: comment.username.userName,
        commentText: comment.commentText,
        commentDate: comment.commentDate,
    }));

    const handleCommentSubmit = async () => {
        if (!commentText.trim()) {
            console.warn("Comment text is empty");
            return; 
        }

        const commentData = {
            artworkID: artwork.id,
            userID: currentUser.id, 
            commentText: commentText,
            commentDate: new Date().toISOString(),
        };

        try {
            const result = await commentService.addComment(commentData);
            console.log('Comment submitted:', result);
            setCommentText(''); 
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
(
                    <>
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
                    </>
                )
            </div>
        </div>
    );
};

export default ArtworkModal;
