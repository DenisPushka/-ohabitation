import './App.css'
import './Components/Cards/Content.css'
import Header from './Components/Header/Header'
import CardCohabitation from './Components/Cards/CardCohabitation'

const App = () => {
  return (
    <div className="app-wrapper">
      <Header />
      <div className="marg">
        <content>
          <CardCohabitation />
          <CardCohabitation />
          <CardCohabitation />
          <CardCohabitation />
        </content>
      </div>
    </div>
  )
}

export default App
