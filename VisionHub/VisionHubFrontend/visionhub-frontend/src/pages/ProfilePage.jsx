import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { userService, artworkService } from '../services/apiService';
import { authService } from '../services/authService';
import TopBanner from '../components/TopBanner';
import ArtworkList from '../components/ArtworkList';

const ProfilePage = () => {
    const { userId } = useParams();
    const navigate = useNavigate();
    const [user, setUser] = useState(null);
    const [artworks, setArtworks] = useState([]);
    const [isOwnProfile, setIsOwnProfile] = useState(false);

    useEffect(() => {
        const fetchProfile = async () => {
            try {
                const loggedInUserId = authService.getUserId();
                setIsOwnProfile(loggedInUserId === parseInt(userId, 10));

                const userData = await userService.getUser(userId || loggedInUserId);
                setUser(userData);

                const userArtworks = await artworkService.getArtworksByUser(userId || loggedInUserId);
                setArtworks(userArtworks);
            } catch (error) {
                console.error('Error fetching profile:', error);
            }
        };

        fetchProfile();
    }, [userId]);

    const handleEditProfile = () => {
        navigate('/edit-profile');
    };

    return (
        <div className="profile-page">
            <TopBanner />

            <section className="profile-header">
                {user && (
                    <>
                        <div className="profile-details">
                            <h1>{user.name}</h1>
                            <p><strong>Username:</strong> {user.username}</p>
                            <p><strong>Email:</strong> {user.email}</p>
                            <p><strong>Biography:</strong> {user.biography || 'No biography provided.'}</p>
                            <p><strong>Birthdate:</strong> {user.birthdate ? new Date(user.birthdate).toLocaleDateString() : 'Not provided'}</p>
                        </div>
                        {isOwnProfile && (
                            <button className="edit-profile-button" onClick={handleEditProfile}>
                                Edit Profile
                            </button>
                        )}
                    </>
                )}
            </section>

            <section className="artwork-section">
                <h2>{isOwnProfile ? 'My Artworks' : `${user?.username}'s Artworks`}</h2>
                <ArtworkList artworks={artworks} />
            </section>
        </div>
    );
};

export default ProfilePage;
