// api.bible - Browse Bible books, chapters, and verses
// Get a free API key at https://www.api.bible/
const BIBLE_API_KEY = 'EuLs44tnRGE5lWyrZk7PR'; 
const BIBLE_API_URL = 'https://rest.api.bible/v1';

const headers = {
  'api-key': BIBLE_API_KEY
};

const TRANSLATIONS ={
    NIV:'78a9f6124f344018-01',
    NLT:'d6e14a625393b4da-01',
    AMP:'a81b73293d3080c9-01'
};
export const getBooks = (translation = 'NIV') =>
  fetch(`${BIBLE_API_URL}/bibles/${TRANSLATIONS[translation]}/books`, { headers })
    .then(r => r.json());

export const getChapters = (bookId) =>
  fetch(`${BIBLE_API_URL}/books/${bookId}/chapters`, { headers })
    .then(r => r.json());

export const getVerses = (chapterId) =>
  fetch(`${BIBLE_API_URL}/chapters/${chapterId}/verses`, { headers })
    .then(r => r.json());

export const getVerseText = (verseId) =>
  fetch(`${BIBLE_API_URL}/verses/${verseId}`, { headers })
    .then(r => r.json());