import './App.css'
import Header from './Components/Header'
import MainContent from './Components/MainContent'

const App = () => {
  return (
    <div className="app-wrapper">
      <Header />
      <div className="marg">
        <content>
          <MainContent />
          <MainContent />
          <MainContent />
          <MainContent />
        </content>
      </div>
    </div>
  )
}

export default App
