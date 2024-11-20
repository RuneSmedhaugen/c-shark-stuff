import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { userService, artworkService } from '../services/apiService';
import { useAuth } from '../services/AuthContext'; // Import useAuth to access context
import ArtworkList from '../components/ArtworkList';

const ProfilePage = () => {
    const { userId } = useParams();
    const navigate = useNavigate();
    const { currentUser } = useAuth(); // Get authentication state from context
    const [user, setUser] = useState(null);
    const [artworks, setArtworks] = useState([]);
    const [isOwnProfile, setIsOwnProfile] = useState(false);
    const [error, setError] = useState('');

    useEffect(() => {
        const fetchProfile = async () => {
            try {
                // If userId is provided in params, fetch that profile, else use currentUser
                const loggedInUserId = currentUser?.userId; // Access currentUser from context
                const idToFetch = userId || loggedInUserId; // Use userId param if available, otherwise use logged-in user

                // Check if the profile is the logged-in user's profile
                setIsOwnProfile(loggedInUserId === parseInt(userId, 10));

                // Fetch user data
                const userData = await userService.getUser(idToFetch);
                setUser(userData);

                // Fetch user artworks
                const userArtworks = await artworkService.getArtworksByUser(idToFetch);
                setArtworks(userArtworks);

                setError('');
            } catch (error) {
                setError('Failed to load profile or artworks.');
                console.error('Error fetching profile:', error);
            }
        };

        if (userId || currentUser?.userId) {
            fetchProfile();
        } else {
            setError('No userId available to fetch profile.');
        }
    }, [userId, currentUser?.userId]); // Add dependencies to check userId or currentUser

    const handleEditProfile = () => {
        if (!currentUser) {
            // Redirect to login if trying to edit without being logged in
            navigate('/login');
        } else {
            navigate('/edit-profile');
        }
    };

    const handleBackToHome = () => {
        navigate('/');
    };

    return (
        <div className="profile-page">
            <section className="profile-header">
                {error ? (
                    <p className="error-message">{error}</p>
                ) : user ? (
                    <>
                        <div className="profile-details">
                            <h1>{user.name}</h1>
                            <p><strong>Username:</strong> {user.username}</p>
                            <p><strong>Email:</strong> {user.email}</p>
                            <p><strong>Biography:</strong> {user.biography || 'No biography provided.'}</p>
                            <p><strong>Birthdate:</strong> {user.birthdate ? new Date(user.birthdate).toLocaleDateString() : 'Not provided'}</p>
                        </div>
                        {isOwnProfile && currentUser && ( // Only show edit button for own profile if logged in
                            <button className="edit-profile-button" onClick={handleEditProfile}>
                                Edit Profile
                            </button>
                        )}
                    </>
                ) : (
                    <p>Loading profile...</p>
                )}
                <button className="back-to-home-button" onClick={handleBackToHome}>
                    Back to Home
                </button>
            </section>

            <section className="artwork-section">
                <h2>{isOwnProfile ? 'My Artworks' : `${user?.username || 'User'}'s Artworks`}</h2>
                {artworks.length > 0 ? (
                    <ArtworkList artworks={artworks} />
                ) : (
                    <p>No artworks available.</p>
                )}
            </section>
        </div>
    );
};

export default ProfilePage;
