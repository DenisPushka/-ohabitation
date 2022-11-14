import card from './Card.module.css'
import { Link } from 'react-router-dom'

let CardCohabitation = (props) => {
    return (
        <div className={card.block_content}>
            <img src={props.us.img} />
            Имя: {props.us.FIO}
            <br />
            Здесь должна быть всплывающая инфа о пользователе
            <Link to="/Profile">Перейти</Link>
        </div>
    )
}

export default CardCohabitation