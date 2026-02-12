import { useState } from 'react';
import { createJournalEntry } from '../services/api';

export default function JournalForm({ userId, onEntryCreated }) {
  const [title, setTitle] = useState('');
  const [content, setContent] = useState('');
  const [mood, setMood] = useState('Neutral');
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    setError('');

    try {
      const response = await createJournalEntry(title, content, mood, userId);
      const journalId = response.data.id;

      // Clear form
      setTitle('');
      setContent('');
      setMood('Neutral');

      // Call parent callback to show struggle modal
      onEntryCreated(journalId);
    } catch (err) {
      setError('Failed to create journal entry. Try again.');
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div style={{ maxWidth: '600px', margin: '0 auto', padding: '20px' }}>
      <h2>Write a Journal Entry</h2>
      
      {error && <p style={{ color: 'red' }}>{error}</p>}

      <form onSubmit={handleSubmit}>
        <div>
          <label>Title: </label>
          <input
            type="text"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
            placeholder="Give your entry a title"
            required
            style={{ width: '100%', padding: '8px', marginBottom: '10px' }}
          />
        </div>

        <div>
          <label>Mood: </label>
          <select
            value={mood}
            onChange={(e) => setMood(e.target.value)}
            style={{ padding: '8px', marginBottom: '10px' }}
          >
            <option>Happy</option>
            <option>Neutral</option>
            <option>Sad</option>
            <option>Angry</option>
            <option>Anxious</option>
            <option>Grateful</option>
          </select>
        </div>

        <div>
          <label>Content: </label>
          <textarea
            value={content}
            onChange={(e) => setContent(e.target.value)}
            placeholder="Write your thoughts here..."
            rows={8}
            required
            style={{ width: '100%', padding: '8px', marginBottom: '10px' }}
          />
        </div>

        <button
          type="submit"
          disabled={loading}
          style={{
            padding: '10px 20px',
            backgroundColor: loading ? '#ccc' : '#007bff',
            color: 'white',
            border: 'none',
            borderRadius: '4px',
            cursor: loading ? 'not-allowed' : 'pointer',
          }}
        >
          {loading ? 'Saving...' : 'Save Entry'}
        </button>
      </form>
    </div>
  );
}
