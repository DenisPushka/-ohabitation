import {Nav} from "react-bootstrap";
import {Component} from "react";
import "./NewHeader.css";

// Шапка.
class Header extends Component {

    constructor(props) {
        super(props);

        this.showLittleMenu = this.showLittleMenu.bind(this);
        this.checkOpenMenu = this.checkOpenMenu.bind(this);
    }

    /**
     * Показывает меню при нажатии на "гамбургер".
     */
    async showLittleMenu() {
        let openDropdown = document.getElementById('navId');

        openDropdown.className = openDropdown.className !== 'show' ? 'show' : 'hide';

        if (openDropdown.className === 'show') {
            window.setTimeout(function () {
                openDropdown.style.opacity = 1;
                openDropdown.style.transform = 'translateY(0px)';
            }, 0);
        } else if (openDropdown.className === 'hide') {
            openDropdown.style.opacity = 0.2;
            openDropdown.style.transform = 'translateY(-500px)';
        }
    }

    /**
     * Проверка на скрытие "гамбургера".
     */
    async checkOpenMenu() {
        window.onclick = (event: MouseEvent) => {
            if (!event.target.matches('.hamburger')) {
                let openDropdown = document.getElementById('navId');
                if (openDropdown.className === 'show') {
                    openDropdown.style.opacity = 0;
                    openDropdown.style.transform = 'translateY(-500px)';
                    openDropdown.className = 'hide';
                } else {
                    openDropdown.style.opacity = 0.2;
                    openDropdown.style.transform = 'translateY(-500px)';
                }
            }
        };
    }
    
    updateSize() {
        let widthOutput = document.querySelector("#navId");
        let mql = window.matchMedia("(min-width: 820px)");
        if ((mql.matches) && (widthOutput.className !== 'nav')){
            widthOutput.className = 'nav';
            widthOutput.style.opacity = null;
            widthOutput.style.transform = null;
            // queue: true;
        }
    }

    render() {
        return (<>
            <header className={"newHeader"} onClick={this.checkOpenMenu}>
                <nav>

                    <div>
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
                        <li><a href="#">Services</a></li>
                        <li><a href="#">Contact</a></li>
                    </ul>

                </nav>
            </header>
        </>);
    }
}

export default Header;
