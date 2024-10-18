import React, { useState } from 'react';
import { artworkService } from '../services/apiService';
import Layout from '../components/Layout.jsx';

const UploadArtwork = () => {
    const [artworkData, setArtworkData] = useState({
        UserID: '',
        Title: '',
        Description: '',
        ImageUrl: '', 
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setArtworkData({
            ...artworkData,
            [name]: value,
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await artworkService.addArtwork(artworkData);
            alert('Artwork uploaded successfully!');
        } catch (error) {
            console.error('Error uploading artwork:', error);
        }
    };

    return (
        <Layout>
            <div>
                <h2>Upload Artwork</h2>
                <form onSubmit={handleSubmit}>
                    <input
                        type="text"
                        name="UserID"
                        placeholder="User ID"
                        value={artworkData.UserID}
                        onChange={handleChange}
                    />
                    <input
                        type="text"
                        name="Title"
                        placeholder="Title"
                        value={artworkData.Title}
                        onChange={handleChange}
                    />
                    <textarea
                        name="Description"
                        placeholder="Description"
                        value={artworkData.Description}
                        onChange={handleChange}
                    />
                    <input
                        type="text"
                        name="ImageUrl"
                        placeholder="Image URL"
                        value={artworkData.ImageUrl}
                        onChange={handleChange}
                    />
                    <button type="submit">Upload</button>
                </form>
            </div>
        </Layout>
    );
};

export default UploadArtwork;
