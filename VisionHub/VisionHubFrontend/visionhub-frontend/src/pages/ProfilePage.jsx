import React from 'react';

const ProfilePage = () => {
    // Example: Fetch user data from API or local storage
    const user = {
        username: 'Username',
        email: 'user@example.com',
        // Add more fields as needed
    };

    return (
        <div className="profile-page">
            <h2>User Profile</h2>
            <p>Username: {user.username}</p>
            <p>Email: {user.email}</p>
            {/* Include other fields and actions (e.g., update profile) */}
        </div>
    );
};

export default ProfilePage;
