import React, {Component} from 'react';

/**
 * Прослушивальщик изменения окна.
 * */
class EventChangeWindow extends Component {

    state = {
        // Ширина.
        width: 0,
        // Высота.
        height: 0
    };
    
    // Ширина окна, при котором изменяется шапка (изменяется класс на navId у шапки).
    needSizeWindow = 600;

    constructor(props) {
        super(props);

        this.setState({width: window.innerWidth, height: window.innerHeight});
    }

    render() {
        let widthOutput = document.querySelector("#navId");

        if (this.state.width > this.needSizeWindow) { 
            widthOutput.className = 'nav';
            widthOutput.style.opacity = null;
            widthOutput.style.transform = null;
        }

        // return <span>Window size: {this.state.width} x {this.state.height}</span>;
        return <div></div>;
    }

    /**
     * Обновление размеров окна.
     * */
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