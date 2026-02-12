import {useState, useEffect} from 'react';
import axios from 'axios';
//const API_URL = 'http://localhost:5180';

function App() {
  const [message, setMessage] = useState("Waiting for the kitchen...");

  useEffect(() => {
    // CHANGE THIS URL to match your dotnet window!
    // Example: https://localhost:7123/weatherforecast
    axios.get('http://localhost:5180/api/Journal')
      .then(response => {
        setMessage("The Kitchen says: " + JSON.stringify(response.data));
      })
      .catch(error => {
        setMessage("Error: The kitchen is closed. " + error.message);
      });
  }, []);

  return (
    <div style={{ padding: "50px" }}>
      <h1>Restaurant Status</h1>
      <p>{message}</p>
    </div>
  );
}

export default App;
