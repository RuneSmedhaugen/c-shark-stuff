import { useState } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import HomePage from './pages/HomePage';
import UploadArtwork from './pages/UploadArtwork';
import Profile from './components/Profile';
import RegisterPage from './pages/RegisterPage';

const App = () => {
    const [isDarkMode] = useState(false);


    return (
        <Router>
            <div className={isDarkMode ? 'app dark-mode' : 'app'}>

                <Routes>
                    <Route path="/" element={<HomePage isDarkMode={isDarkMode} />} />
                    <Route path="/upload" element={<UploadArtwork isDarkMode={isDarkMode} />} />
                    <Route path="/register" element={<RegisterPage isDarkMode={isDarkMode} />} />
                    <Route path="/profile" element={<Profile isDarkMode={isDarkMode} />} />

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
