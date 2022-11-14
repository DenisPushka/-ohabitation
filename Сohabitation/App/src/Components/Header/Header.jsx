import bm from './ButtonMain.module.css'
import top from './Top.module.css'
import head from './Header.module.css'

let Header = () => {
    return (
        <header className={head.header}>
            <img src="MainPhoto.jpg" />
            <div className={top.top}>
                <div className={top.topLeft}>Cohabitation</div>
                <div className={top.topRight}>
                    <a href="">Вход </a>
                    <a href="">Регистрация</a>
                </div>
            </div>
            <div className='centered'> Мы поможем с соседом </div>
            <button type="button" className={`${head.button} ${bm.fill}`}>Фильтр</button>
        </header>
    )
}

export default Header;
