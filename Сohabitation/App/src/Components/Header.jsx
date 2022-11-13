import '../css/ButtonMain.css'
import '../css/Top.css'
import '../css/Header.css'

let Header = () => {
    return (
        <header className="header">
            <img src="MainPhoto.jpg" />
            <div className="top">
                <div className="top-left">Cohabitation</div>
                <div className="top-right">
                    <a href="">Вход </a>
                    <a href="">Регистрация</a>
                </div>
            </div>
            <div className='centered'> Мы поможем с соседом </div>
            <button type="button" className='fill'>Фильтр</button>
        </header>
    )
}

export default Header;
