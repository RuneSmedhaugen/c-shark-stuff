import React, { useEffect, useState } from 'react';
import axios from 'axios';  // Make sure to install axios with `npm install axios`

const UserInfo = () => {
    const [users, setUsers] = useState([]); // State to hold all users
    const [error, setError] = useState(null); // State to handle errors

    useEffect(() => {
        const fetchUsers = async () => {
            try {
                const response = await axios.get(`https://localhost:7213/api/user/all`);
                setUsers(response.data); // Assuming the response contains an array of users
            } catch (err) {
                console.error(err);
                setError('Failed to fetch user data.');
            }
        };

        fetchUsers();
    }, []); 

    return (
        <div className="user-info">
            {error && <p>{error}</p>}
            {!error && users.length === 0 && <p>Loading user data...</p>}
            {users.length > 0 && (
                <div>
                    <h2>Users Info</h2>
                    {users.map((user, index) => (
                        <div key={index} className="user-card">
                            <h3>User {index + 1}</h3>
                            <p><strong>Username:</strong> {user.userName}</p>
                            <p><strong>Email:</strong> {user.email}</p>
                            <p><strong>Name:</strong> {user.name}</p>
                            <p><strong>Birthdate:</strong> {user.birthDate}</p>
                            <p><strong>Register Date:</strong> {new Date(user.registerDate).toLocaleDateString()}</p>
                            <p><strong>UserId:</strong> {user.userId}</p>
                        </div>
                    ))}
                </div>
            )}
        </div>
    );
};

export default UserInfo;
