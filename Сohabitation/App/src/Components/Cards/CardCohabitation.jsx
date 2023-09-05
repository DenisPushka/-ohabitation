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
        return (
            <>
                <>{this.props.user.contactUser.name} </>
                <>{this.props.user.contactUser.lastname} </>
                <>{this.props.user.contactUser.patronymic} <br/></>
                Возраст: <>{this.props.user.contactUser.age} </>
                
                Город: <>{this.props.user.contactUser.city.name}</><br/>
                <img src={this.props.user.contactUser.photo}/>
                
                <Nav.Link
                    href="/ProfileUser"
                    class={"block_content"}>
                    Перейти
                </Nav.Link>

            </>
        );
    }

}

export default CardCohabitation;