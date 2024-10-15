import React, { useState, useEffect } from 'react';
import { artworkService } from '../services/apiService.js';

const ArtGallery = () => {
  const [artworks, setArtworks] = useState([]);

  useEffect(() => {
    // Fetch random artworks
    artworkService.getAllArtworks()
      .then(response => {
        setArtworks(response);
      })
      .catch(error => {
        console.error('Error fetching artworks:', error);
      });
  }, []);

  return (
    <div>
      <h3>Featured Artworks</h3>
      <div className="art-grid">
        {artworks.map((art, index) => (
          <div key={index} className="art-item">
            <img src={art.ImageUrl} alt={art.Title} />
            <p>{art.Title}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default ArtGallery;
