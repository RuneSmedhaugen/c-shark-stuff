/*
import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom'; // To get the userId from the URL
import ProfileHeader from './ProfileHeader';
import UserStats from './UserStats';
import UploadedArtworks from './UploadedArtworks';
import EditProfileButton from './EditProfileButton';
import Layout from './Layout';  // This includes your top banner, search bar, etc.

const ProfilePage = () => {
  const { userId } = useParams(); // Get userId from the URL, if it exists
  const [user, setUser] = useState(null);
  const [stats, setStats] = useState({});
  const [artworks, setArtworks] = useState([]);
  const [isOwnProfile, setIsOwnProfile] = useState(false);

  useEffect(() => {
    const fetchUserData = async () => {
      // If there's no userId in the URL, fetch the current logged-in user
      const endpoint = userId ? `/api/users/${userId}` : '/api/users/me';

      const userData = await fetch(endpoint); // Fetch user data dynamically
      const userStats = await fetch(`${endpoint}/stats`); // Fetch the stats for the user
      const userArtworks = await fetch(`${endpoint}/artworks`); // Fetch their artworks

      setUser(await userData.json());
      setStats(await userStats.json());
      setArtworks(await userArtworks.json());

      // Check if the profile belongs to the logged-in user (for showing the Edit button)
      if (!userId) setIsOwnProfile(true);
    };

    fetchUserData();
  }, [userId]); // Rerun this effect if the userId in the URL changes

  if (!user) return <p>Loading...</p>;

  return (
    <Layout>
      <div className="profile-page">
        <ProfileHeader user={user} />
        <UserStats stats={stats} />
        <UploadedArtworks artworks={artworks} />
        
        {isOwnProfile && (
          <EditProfileButton onEditClick={() => alert('Edit Profile clicked!')} />
        )}
      </div>
    </Layout>
  );
};

export default ProfilePage;
*/