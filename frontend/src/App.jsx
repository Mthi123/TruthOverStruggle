import { useState } from 'react';
import Login from './components/Login';
import JournalForm from './components/JournalForm';
import './App.css';

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [userId, setUserId] = useState(null);
  const [lastJournalId, setLastJournalId] = useState(null);

  const handleLogin = (id) => {
    setUserId(id);
    setIsLoggedIn(true);
  };

  const handleEntryCreated = (journalId) => {
    setLastJournalId(journalId);
    // TODO: Show struggle modal here
    alert(`Journal entry created! ID: ${journalId}\nNext: Struggle modal would appear here.`);
  };

  return (
    <div className="App">
      {!isLoggedIn ? (
        <Login onLogin={handleLogin} />
      ) : (
        <JournalForm userId={userId} onEntryCreated={handleEntryCreated} />
      )}
    </div>
  );
}

export default App;
