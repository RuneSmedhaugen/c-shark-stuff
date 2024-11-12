import { useState } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import HomePage from './pages/HomePage';
import UploadArtwork from './pages/UploadArtwork';
import ProfilePage from './pages/ProfilePage';
import RegisterPage from './pages/RegisterPage';
import SearchResultsPage from './pages/SearchResultsPage';

const App = () => {
    const [isDarkMode] = useState(false);


    return (
        <Router>
            <div className={isDarkMode ? 'app dark-mode' : 'app'}>

                <Routes>
                    <Route path="/" element={<HomePage isDarkMode={isDarkMode} />} />
                    <Route path="/upload" element={<UploadArtwork isDarkMode={isDarkMode} />} />
                    <Route path="/register" element={<RegisterPage isDarkMode={isDarkMode} />} />
                    <Route path="/profile" element={<ProfilePage isDarkMode={isDarkMode} />} />
                    <Route path="/search" element={<SearchResultsPage isDarkMode={isDarkMode} />} />

                    {/* Future Routes */}
                    {/* <Route path="/profile/edit" element={<EditUserInfo isDarkMode={isDarkMode} />} /> */}
                    {/* <Route path="/profile/change-password" element={<ChangePassword isDarkMode={isDarkMode} />} /> */}
                    {/* <Route path="/profile/delete" element={<DeleteProfile isDarkMode={isDarkMode} />} /> */}
                </Routes>
            </div>
        </Router>
    );
};

export default App;
