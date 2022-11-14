import bm from './ButtonMain.module.css'
import top from './Top.module.css'
import head from './Header.module.css'
import { Link } from 'react-router-dom'


let Header = () => {
    return (
        <header className={head.header}>
            <img src="MainPhoto.jpg" />
            <div className={top.top}>
                <div className={top.topLeft}>
                     <Link to="/"> Cohabitation</Link>
                    </div>
                <div className={top.topRight}>
                    <Link to="">Вход </Link>
                    <Link to="">Регистрация</Link>
                </div>
            </div>
            <div className='centered'> Мы поможем с соседом </div>
            <button type="button" className={`${head.button} ${bm.fill}`}>Фильтр</button>
        </header>
    )
}

export default Header;
