import './css/App.css'
import './css/Content.css'
import Header from './Components/Header/Header'
import { Cards } from './Components/Cards/Cards'
import { Profile } from './Components/Profile/Profile'
import { Routes, Route } from 'react-router-dom'

// Переделать header, нужно, чтобы фотка с кнопкой были отдельно
const App = (props) => {
  return (
    <>
      <Header />
      <div className="app-wrapper">
        <Routes>
          <Route path="/" element={<Cards />} />
          <Route path="/Profile" element={<Profile />} /> 
          {/* <Route path='*'/> все возм пути*/}
        </Routes>
      </div>
    </>
  )
}

export default App
