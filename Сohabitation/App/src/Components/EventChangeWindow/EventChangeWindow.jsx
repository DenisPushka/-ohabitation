import React, {Component} from 'react';

/**
 * Прослушивальщик изменения окна.
 */
class EventChangeWindow extends Component {

    state = {
        // Ширина.
        width: 0,
        // Высота.
        height: 0
    };
    
    // Ширина окна, при котором изменяется шапка (изменяется класс на navId у шапки).
    needSizeWindow = 425;

    constructor(props) {
        super(props);

        this.setState({width: window.innerWidth, height: window.innerHeight});
    }

    /**
     * При развернутом меню в режиме мобильного устройста, если мы нажимаем на какой-либо элемент,
     * кроме кнопки-гамбургер (тот, что с классом ".hamburger"), у нас при условии, что есть у 
     * списка меню класс ".show", скрывается это меню
     */
    async checkOpenMenu() {
        window.onclick = (event: MouseEvent) => {
            if (!event.target.matches('.hamburger')) {
                let openDropdown = document.getElementById('navId');
                if (openDropdown.className === 'show') {
                    openDropdown.style.opacity = 0;
                    openDropdown.style.transform = 'translateY(-500px)';
                    openDropdown.className = 'hide';
                }
            }
        };
    }

    render() {
        let widthOutput = document.querySelector("#navId");

        if (this.state.width > this.needSizeWindow) { 
            widthOutput.className = 'nav';
            widthOutput.style.opacity = null;
            widthOutput.style.transform = null;
        }
        this.checkOpenMenu().then();
        // return <span>Window size: {this.state.width} x {this.state.height}</span>;
        return <div></div>;
    }

    /**
     * Обновление размеров окна.
     */
    updateDimensions = () => {
        this.setState({width: window.innerWidth, height: window.innerHeight});
    };


    componentDidMount() {
        window.addEventListener('resize', this.updateDimensions);
    }

    componentWillUnmount() {
        window.removeEventListener('resize', this.updateDimensions);
    }
}

export default EventChangeWindow;