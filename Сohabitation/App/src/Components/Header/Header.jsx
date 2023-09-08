import {Nav} from "react-bootstrap";
import {Component} from "react";
import EventChangeWindow from "../EventChangeWindow/EventChangeWindow";
import "./NewHeader.css";

// Шапка.
class Header extends Component {

    constructor(props) {
        super(props);

        this.showLittleMenu = this.showLittleMenu.bind(this);
        // this.checkOpenMenu = this.checkOpenMenu.bind(this); 
    }

    /**
     * Показывает меню при нажатии на "гамбургер".
     */
    async showLittleMenu() {
        let openDropdown = document.getElementById('navId');

        openDropdown.className = openDropdown.className !== 'show' ? 'show' : 'hide';

        if (openDropdown.className === 'show') {
                openDropdown.style.opacity = 1;
                openDropdown.style.transform = 'translateY(0px)';
        } else if (openDropdown.className === 'hide') {
            openDropdown.style.opacity = 0;
            openDropdown.style.transform = 'translateY(-500px)';
        }
    }

    /**
     * Проверка на скрытие "гамбургера".
     */
    // async checkOpenMenu() {
    //     window.onclick = (event: MouseEvent) => {
    //         if (!event.target.matches('.hamburger')) {
    //             let openDropdown = document.getElementById('navId');
    //             if (openDropdown.className === 'show') {
    //                 openDropdown.style.opacity = 0;
    //                 openDropdown.style.transform = 'translateY(-500px)';
    //                 openDropdown.className = 'hide';
    //             } else {
    //                 openDropdown.style.opacity = 0.2;
    //                 openDropdown.style.transform = 'translateY(-500px)';
    //             }
    //         }
    //     };
    // }




    render() {
        return (<>
            <EventChangeWindow/>
            
            <header className={"newHeader"} >
                <nav>

                    <div class="logotype">
                        Name
                    </div>

                    <div class="hamburger menu-toggle" onClick={this.showLittleMenu}>
                        <div class="line"></div>
                        <div class="line"></div>
                        <div class="line"></div>
                    </div>

                    <ul class="nav" id="navId">
                        <li><Nav.Link href="/#">Главная</Nav.Link></li>
                        <li><Nav.Link href="/ProfileUser">Профиль</Nav.Link></li>
                        <li><Nav.Link href="/LogIn">Вход</Nav.Link></li>
                        <li><Nav.Link href="/SignUp">Регистрация</Nav.Link></li>
                    </ul>

                </nav>
            </header>
        </>);
    }
}

export default Header;
