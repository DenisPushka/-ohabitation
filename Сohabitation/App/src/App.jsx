import './css/App.css'
import './css/Content.css'
import Header from './Components/Header/Header'
import { Cards } from './Components/Cards/Cards'
import { Routes, Route } from 'react-router-dom'
import { ProfileComponent } from './Components/Profile/Profile'
// Переделать header, нужно, чтобы фотка с кнопкой были отдельно
const App = (props) => {
  return (
    <>
      <Header />
      <div className="app-wrapper">
        <Routes>
          <Route path="/" element={<Cards />} />
          <Route path="/Profile" element={<ProfileComponent />} /> 
          {/* <Route path='*'/> все возм пути*/}
        </Routes>
      </div>
    </>
  )
}

export default App
