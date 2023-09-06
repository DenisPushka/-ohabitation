import {Component} from "react";
import {Nav} from "react-bootstrap";
import "./Card.css";

// Карта пользователя.
class CardCohabitation extends Component {
    state = {
        props: null
    };

    constructor(props) {
        super(props);

        this.state.props = props;
        // this.setState(props, props);
    }

    render() {
        const image = new Image();
        image.src = 'data:image/png;base64,' + this.props.user.contactUser.photo;
        
        return (
            <>
                <>{this.props.user.contactUser.name} </>
                <>{this.props.user.contactUser.lastname} </>
                <>{this.props.user.contactUser.patronymic} <br/><br/></>
                Возраст: <>{this.props.user.contactUser.age} </> <br/>

                Город: <>{this.props.user.contactUser.city.name}</><br/>
                {/*Университет: <>{this.props.user.contactUser.university.name}</><br/>*/}


                <img src={image.src} alt={image.title}/>    
                <Nav.Link
                    href="/ProfileUser">
                    Перейти
                </Nav.Link>

            </>
        );
    }

}

export default CardCohabitation;