import axios from 'axios';

const API_URL = 'http://localhost:5180/api';

export const getAllStruggles = () => 
    axios.get(`${API_URL}/Struggle`);

export const createStruggle = (name, description, root) => 
  axios.post(`${API_URL}/Struggle`, { name, description, root });

export const linkStruggleToEntry = (struggleId, journalEntryId) =>
  axios.post(`${API_URL}/Struggle/${struggleId}`, journalEntryId);

export const linkScriptureToStruggle = (struggleId, scriptureData) =>
  axios.post(`${API_URL}/Scripture/${struggleId}`, scriptureData);

export const createJournalEntry = (title, content, mood, userId) =>
  axios.post(`${API_URL}/Journal`, { title, content, mood, userId });