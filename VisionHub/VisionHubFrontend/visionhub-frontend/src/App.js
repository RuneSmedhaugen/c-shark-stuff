import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import HomePage from './pages/HomePage';
import AccountCreationPage from './pages/AccountCreationPage';
import UploadArtwork from './pages/UploadArtwork';
import ProfilePage from './pages/ProfilePage';
import Register from './pages/AccountCreationPage';

const App = () => {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/account-creation" element={<AccountCreationPage />} />
                <Route path="/upload" element={<UploadArtwork />} />
                <Route path="/profile" element={<ProfilePage />} />
                <Route path="/register" element={<Register />} />
                {/* Add routes for editing user info, changing password, and deleting profile */}
            </Routes>
        </Router>
    );
};

export default App;
