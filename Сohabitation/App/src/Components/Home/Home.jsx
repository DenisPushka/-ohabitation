import React, { Component } from "react";
import { connect } from "react-redux";
import Header from "../Header/Header";
import CardCohabitation from "../Cards/CardCohabitation";
import "./Home.css";
import "../Cards/Card.css";

// Домашняя страница.
class Home extends Component {

    state = {
        // Пользователи.
        users: [
            // Данные по умолчанию.
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

    // Минимальное количество пользователей.
    minCountUsers = 1;

    // Количество размеров карточки (small, medium, large).
    countSize = 3;

    constructor(props) {
        super(props);
    }

    async componentDidMount() {
        if (this.props.users === null) {
            return;
        }

        if (this.props.users.length <= this.minCountUsers) {
            await this.getAllUsers();
        } else {
            this.setState({ users: this.props.users });
        }
    }

    /** 
     * Получение всех пользователей.
     */
    async getAllUsers() {
        fetch("/api/User/GetAllUsers", {
            method: 'GET'
        })
            .then(res => res.json())
            .then(async data => {
                let buffer = data.concat(this.state.users);
                this.setState({ users: buffer });

                await this.props.onGetAllUsers(buffer);
            }
            );
    }

    render() {
        return (
            <>
                <Header />
                <div class="pin_container">
                    {/* Для наглядности добавлено несколько карточек без информации. */}
                    <div class={"card card_large"}></div>
                    <div class={"card card_medium"}></div>

                    {
                        // Перечисление всех пользователей.
                        this.state.users !== null && this.state.users.map((user) => {

                            let sizeCard = "card card_large";

                            switch (Math.floor(Math.random() * this.countSize)) {
                                case 1:
                                    sizeCard = "card card_small";
                                    break;
                                case 2:
                                    sizeCard = "card card_medium";
                                    break;
                                case 3:
                                    sizeCard = "card card_large";
                                    break;
                            }

                            return (
                                <div className={sizeCard}>
                                    <CardCohabitation user={user} />
                                </div>
                            );
                        })
                    }
                </div>
            </>
        );
    }
}

export default connect(
    state => ({
        user: state.user,
        users: state.users
    }),
    dispatch => ({
        onGetAllUsers: (data) => {
            dispatch({ type: 'GET_USERS', payload: data });
        }
    })
)(Home);