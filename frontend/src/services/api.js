import axios from 'axios';

const API_URL = 'http://localhost:5180/api';

//Struggle Controller
export const getAllStruggles = () => 
    axios.get(`${API_URL}/Struggle`);

export const createStruggle = (name, description, root) => 
  axios.post(`${API_URL}/Struggle`, { name, description, root });

export const linkStruggleToEntry = (struggleId, journalEntryId) =>
  axios.post(`${API_URL}/Struggle/${struggleId}`, journalEntryId);

export const getJournalEntryByStruggle = (struggleId) =>
    axios.get(`${API_URL}/Struggle/${struggleId}/journal`);

export const getScriptureByStruggle = (struggleId) =>
    axios.get(`${API_URL}/Struggle/${struggleId}/scripture`);

export const updateStruggle = (struggleId) =>
    axios.put(`${API_URL}/Struggle/${struggleId}`);

// missing - delete
// ------------------------------------------------------------------

//Scripture Controller
export const linkScriptureToStruggle = (struggleId, scriptureData) =>
  axios.post(`${API_URL}/Scripture/${struggleId}`, scriptureData);

export const deleteStruggleLinkToScripture = (scriptureData) =>
    axios.delete(`${API_URL}/Scripture/${scriptureData}`);

//Journal Controller
export const getJournalByDate = (date) =>
    axios.get(`${API_URL}/Journal/${date}`);
// how to make the interface a calendar esssentially/ another api?

export const getJournalEntry = (journalId) =>
    axios.get(`${API_URL}/Journal/${journalId}`);

export const createJournalEntry = (title, content, mood, userId) =>
  axios.post(`${API_URL}/Journal`, { title, content, mood, userId });

export const updateJournal = (journalId) =>
    axios.put(`${API_URL}/Journal/${journalId}`);

export const DeleteJournal = (journalId) =>
    axios.delete(`${API_URL}/Journal/${journalId}`);



