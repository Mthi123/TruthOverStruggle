import { useState } from 'react';

export default function Login({ onLogin }) {
  const [userId, setUserId] = useState(1); // Placeholder

  const handleLogin = () => {
    // TODO: Implement real authentication
    onLogin(userId);
  };

  return (
    <div style={{ textAlign: 'center', padding: '50px' }}>
      <h1>Truth Over Struggle</h1>
      <p>Journal your journey. Find scripture. Overcome struggle.</p>
      <button onClick={handleLogin} style={{ padding: '10px 20px', fontSize: '16px' }}>
        Login (Placeholder)
      </button>
    </div>
  );
}
