import React, {Component} from "react";
import Header from "../Header/Header";
import CardCohabitation from "../Cards/CardCohabitation";
import "./Home.css";

// Домашняя страница.
class Home extends Component {

    state = {
        // Пользователи.
        users: [],
        // Данные по умолчанию.
        defaultData: [
            {
                minMoney: 0,
                maxMoney: 0,
                contactUser: {
                    name: 'Denis',
                    lastname: '',
                    patronymic: '',
                    city: {
                        name: ''
                    },
                    course: 0,
                    dateBirthday: '',
                    district: {
                        name: ''
                    },
                    email: '',
                    gender: '',
                    linkVk: '',
                    linkTelegram: '',
                    phone: '',
                    university: {
                        name: ''
                    },
                    age: 20,
                    photo: 'My.JPG'
                }
            },
            {
                minMoney: 0,
                maxMoney: 0,
                contactUser: {
                    name: 'Sergey',
                    lastname: '',
                    patronymic: '',
                    city: {
                        name: ''
                    },
                    course: 0,
                    dateBirthday: '',
                    district: {
                        name: ''
                    },
                    email: '',
                    gender: '',
                    linkVk: '',
                    linkTelegram: '',
                    phone: '',
                    university: {
                        name: ''
                    },
                    age: 20,
                    photo: 'Serega.JPG'
                }
            },
            {
                minMoney: 0,
                maxMoney: 0,
                contactUser: {
                    name: 'Grisha',
                    lastname: '',
                    patronymic: '',
                    city: {
                        name: ''
                    },
                    course: 0,
                    dateBirthday: '',
                    district: {
                        name: ''
                    },
                    email: '',
                    gender: '',
                    linkVk: '',
                    linkTelegram: '',
                    phone: '',
                    university: {
                        name: ''
                    },
                    age: 20,
                    photo: 'Beer.JPG'
                }
            }
        ]
    };

    constructor(props) {
        super(props);

    }

    // Получение всех пользователей.
    async componentDidMount() {
        fetch("/api/User/GetAllUsers", {
            method: 'GET'
        })
            .then(res => res.json())
            .then(async data => {
                    let buffer = data.concat(this.state.defaultData);
                    this.setState({users: buffer});
                }
            );
    }

    render() {
        return (
            <>
                <Header/>
                <div className="marg">
                    {
                        // Перечисление всех пользователей.
                        this.state.users.map((user) => {
                            return (
                                <div className="card_small">
                                    <CardCohabitation user={user}/>
                                </div>
                            );
                        })
                    }
                </div>
            </>
        );
    }
}

export default Home;