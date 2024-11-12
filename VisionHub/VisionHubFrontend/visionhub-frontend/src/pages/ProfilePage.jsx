import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { userService, artworkService } from '../services/apiService';
import { authService } from '../services/authService';
import TopBanner from '../components/TopBanner';
import ArtworkList from '../components/ArtworkList';

const ProfilePage = () => {
    const { userId } = useParams();
    const [user, setUser] = useState(null);
    const [artworks, setArtworks] = useState([]);
    const [isOwnProfile, setIsOwnProfile] = useState(false);

    useEffect(() => {
        const fetchProfile = async () => {
            try {
                const loggedInUserId = authService.getUserId(); // Get current user's ID from authService
                setIsOwnProfile(loggedInUserId === userId);

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

    return (
        <div className="profile-page">
            <TopBanner />

            <div className="profile-info">
                {user && (
                    <>
                        <h2>{user.name}</h2>
                        <p>Username: {user.username}</p>
                        <p>Email: {user.email}</p>
                        <p>Biography: {user.biography}</p>
                        <p>Birthdate: {new Date(user.birthdate).toLocaleDateString()}</p>
                    </>
                )}
            </div>

            <div className="user-artworks">
                <h3>{isOwnProfile ? 'My Artworks' : `${user?.username}'s Artworks`}</h3>
                <ArtworkList artworks={artworks} />
            </div>
        </div>
    );
};

export default ProfilePage;
