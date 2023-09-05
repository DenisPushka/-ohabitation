import bm from './ButtonMain.module.css';
import top from './Top.module.css';
import head from './Header.module.css';
import {Nav} from "react-bootstrap";
import {Component} from "react";

// Шапка.
class Header extends Component {

    constructor(props) {
        super(props);
    }

    render() {
        return (<>
            <header className={head.header}>
                <img className={head.img_wrap} src={"test_pictur_two.jpg"}/>

                <div className={top.top}>
                    <div className={top.topLeft}>
                        <Nav.Link href="*"> Cohabitation</Nav.Link>
                    </div>

                    <div className={top.topRight}>
                        <Nav.Link href="LogIn">Вход </Nav.Link>
                        <Nav.Link href="SignUp">Регистрация</Nav.Link>
                    </div>
                </div>

                {/*<div className="centered"> Мы поможем с соседом</div>*/}

                <button type="button" className={`${head.button} ${bm.fill}`}>
                    Фильтр
                </button>

            </header>
        </>);
    }
}


export default Header;
