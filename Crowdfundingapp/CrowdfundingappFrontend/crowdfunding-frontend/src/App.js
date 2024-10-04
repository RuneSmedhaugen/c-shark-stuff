import React, { useEffect, useState } from 'react';
import { getCampaigns, createCampaign } from './services/campaignService';

function App() {
  const [campaigns, setCampaigns] = useState([]);

  useEffect(() => {
    // Fetch campaigns when component loads
    getCampaigns().then(setCampaigns).catch(console.error);
  }, []);

  return (
    <div className="App">
      <h1>Crowdfunding Campaigns</h1>
      <ul>
        {campaigns.map(campaign => (
          <li key={campaign.id}>
            {campaign.title}: {campaign.description}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App;
