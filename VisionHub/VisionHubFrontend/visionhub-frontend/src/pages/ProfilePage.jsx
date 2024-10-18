import React, { useState, useEffect } from 'react';
import { artworkService, userService } from '../services/apiService';
import EditProfileDropdown from '../components/EditProfileDropdown.jsx';

const ProfilePage = () => {
    const [userData, setUserData] = useState(null);
    const [artworks, setArtworks] = useState([]);
    const [showEditDropdown, setShowEditDropdown] = useState(false);

    useEffect(() => {
        const fetchUserData = async () => {
            try {
                const userId = 'current_user_id';
                const userResponse = await userService.getUser(userId);
                const artworksResponse = await artworkService.getAllArtworks
                setUserData(userResponse);
                setArtworks(artworksResponse);
            } catch (error) {
                console.error('Error fetching user data:', error);
            }
        };

        fetchUserData();
    }, []);

    const handleEditToggle = () => {
        setShowEditDropdown((prev) => !prev);
    };

    return (
        <div className="profile-page">
            <h2>Your Profile</h2>
            {userData && (
                <div className="user-info">
                    <p><strong>Username:</strong> {userData.username}</p>
                    <p><strong>Email:</strong> {userData.email}</p>
                    <p><strong>Biography:</strong> {userData.biography}</p>
                </div>
            )}

            <button onClick={handleEditToggle}>Edit Profile</button>
            {showEditDropdown && <EditProfileDropdown />}

            <h3>Your Artworks</h3>
            <div className="artwork-list">
                {artworks.map((artwork) => (
                    <div key={artwork.id} className="artwork-item">
                        <h4>{artwork.Title}</h4>
                        <img src={artwork.ImageUrl} alt={artwork.Title} />
                        <p>{artwork.Description}</p>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default ProfilePage;
