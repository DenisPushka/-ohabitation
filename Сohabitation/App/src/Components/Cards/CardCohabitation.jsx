import {Component} from "react";
import {Nav} from "react-bootstrap";
import card from './Card.module.css';

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
                <div className={card.block_content}>
                    <>{this.props.user.contactUser.name} </>
                    <>{this.props.user.contactUser.lastname} </>
                    <>{this.props.user.contactUser.patronymic} <br/></>
                    Возраст: <>{this.props.user.contactUser.age} </>
                    Город: <>{this.props.user.contactUser.city.name}</>
                    <img src={this.props.user.contactUser.photo}/>
                    <Nav.Link href="/ProfileUser">Перейти</Nav.Link>
                </div>
            </>
        );
    }

}

export default CardCohabitation;