import React, {Component} from "react";
import {connect} from "react-redux";
import Header from "../Header/Header";
import CardCohabitation from "../Cards/CardCohabitation";
import "./Home.css";

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

    constructor(props) {
        super(props);
    }

    async componentDidMount() {
        if (this.props.users.length <= this.minCountUsers) {
            await this.getAllUsers();
        } else {
            this.setState({users: this.props.users});
        }
    }

    /*
    Получение всех пользователей.
     */
    async getAllUsers() {
        fetch("/api/User/GetAllUsers", {
            method: 'GET'
        })
            .then(res => res.json())
            .then(async data => {
                    let buffer = data.concat(this.state.users);
                    this.setState({users: buffer});

                    await this.props.onGetAllUsers(buffer);
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

export default connect(
    state => ({
        user: state.user,
        users: state.users
    }),
    dispatch => ({
        onGetAllUsers: (data) => {
            dispatch({type: 'GET_USERS', payload: data});
        }
    })
)(Home);