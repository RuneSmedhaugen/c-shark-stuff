import { useState } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import HomePage from './pages/HomePage';
import UploadArtwork from './pages/UploadPage';
import ProfilePage from './pages/ProfilePage';
import RegisterPage from './pages/RegisterPage';
import SearchResultsPage from './pages/SearchResultsPage';
import AuthProvider, { useAuth } from './services/AuthContext';
import TopBanner from './components/TopBanner';
import LoginDropDown from './components/LoginDropDown';

const App = () => {
    const [isDarkMode, setIsDarkMode] = useState(
        localStorage.getItem('isDarkMode') === 'true'
    );

    return (
        <AuthProvider>
            <Router>
                <MainApp isDarkMode={isDarkMode} setIsDarkMode={setIsDarkMode} />
            </Router>
        </AuthProvider>
    );
};

const MainApp = ({ isDarkMode, setIsDarkMode }) => {
    const { login, isLoggedIn, currentUser, logout } = useAuth();
    const [isLoginOpen, setIsLoginOpen] = useState(false);
  
    const openLoginDropdown = () => {
      setIsLoginOpen(true);
    };
  
    const handleLogin = async (username, password) => {
      try {
        await login(username, password);
        setIsLoginOpen(false);
      } catch (err) {
        console.error('Login failed:', err);
        throw new Error('Login failed');
      }
    };
  
    const handleProfile = () => {
      if (currentUser) {
        window.location.href = `/profile/${currentUser.id}`;
      } else {
        console.error('User is not logged in');
      }
    };
  
    return (
      <div className={isDarkMode ? 'app dark-mode' : 'app'}>
        <TopBanner
          handleProfile={handleProfile}
          isLoggedIn={isLoggedIn}
          handleLogout={logout}
          openLoginDropdown={openLoginDropdown}
          isDarkMode={isDarkMode}
          setIsDarkMode={setIsDarkMode}
        />
  
        <Routes>
          <Route path="/" element={<HomePage isDarkMode={isDarkMode} />} />
          <Route path="/upload" element={<UploadArtwork isDarkMode={isDarkMode} />} />
          <Route path="/register" element={<RegisterPage isDarkMode={isDarkMode} />} />
          <Route path="/profile/:id" element={<ProfilePage isDarkMode={isDarkMode} />} />
          <Route path="/search" element={<SearchResultsPage isDarkMode={isDarkMode} />} />
        </Routes>
  
        {isLoginOpen && (
          <div className="dropdown-overlay">
            <LoginDropDown
              closeModal={() => setIsLoginOpen(false)}
              handleLogin={handleLogin}
              isDarkMode={isDarkMode}
            />
          </div>
        )}
      </div>
    );
  };  

export default App;
