import axios from 'axios';

const API_URL = 'https://localhost:7177/api/campaigns'; // Your API URL

export const getCampaigns = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data;
  } catch (error) {
    console.error('Error fetching campaigns:', error);
    throw error;
  }
};

export const createCampaign = async (campaign) => {
  try {
    const response = await axios.post(API_URL, campaign);
    return response.data;
  } catch (error) {
    console.error('Error creating campaign:', error);
    throw error;
  }
};
