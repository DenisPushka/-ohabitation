import React, {Component} from "react";
import {connect} from "react-redux";
import Header from "../Header/Header";
import CardCohabitation from "../Cards/CardCohabitation";
import "./Home.css";
import "../Cards/Card.css";
import photoDenis from '../../public/photoDenis.txt';
import photoSergey from '../../public/photoSerega.txt';
import photoGrigory from '../../public/photoGrisha.txt';

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
                    photo: ''
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
                    photo: ''
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
                    photo: ''
                }
            }
        ]
    };

    // Минимальное количество пользователей.
    minCountUsers = 3;

    // Количество размеров карточки (small, medium, large).
    countSize = 3;

    // Пропорция для отображения минимальной карточки (до преобразования).
    minProportion = 1;

    // Параметр для измения пропорции
    changeProportion = 1.5;

    constructor(props) {
        super(props);

        this.addPhotoToDefaultData(photoDenis, 0);
        this.addPhotoToDefaultData(photoSergey, 1);
        this.addPhotoToDefaultData(photoGrigory, 2);
    }

    /**
     * Добавление фото из файлов .txt (фото в формате .jpeg).
     * @param {Object} photo Файл с данными фотографии.
     * @param {Number} number Номер объекта в массиве.
     * */
    addPhotoToDefaultData(photo, number) {
        fetch(photo)
            .then(r => r.text())
            .then((text) => {
                let buffer = this.state.users.slice();
                buffer[number].contactUser.photo = text;
                this.setState({users: buffer});
            });
    }

    async componentDidMount() {
        // if (this.props.users === null) {
        //     return;
        // }

        if (this.props.users === null || this.props.users.length <= this.minCountUsers) {
            await this.getAllUsers();
        } else {
            this.setState({users: this.props.users});
        }
    }

    /**
     * Получение в state.users всех пользователей.
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

    /**
     * Получение пропорции для карточки.
     * @param {Object} user Пользователь, у которого берутся параметры для высчитывания пропорции.
     * @return {Number} Пропорция в виде целого числа для карточки пользователя.
     * */
    getProportion(user) {
        if (user.contactUser.photo !== null) {
            const image = new Image();
            image.src = 'data:image/png;base64,' + user.contactUser.photo;
            let buffer = (image.naturalHeight / image.naturalWidth);

            if (buffer <= this.minProportion || isNaN(buffer)) {
                buffer = this.changeProportion;
            } else if (buffer >= this.minProportion) {
                buffer *= this.changeProportion;
            }

            return Math.floor(buffer);
        }

        return this.minProportion;
    }

    render() {
        return (
            <>
                <Header/>
                <div class="pin_container">

                    {
                        // Перечисление всех пользователей.
                        this.state.users !== null && this.state.users.map((user) => {

                            const image = new Image();
                            image.src = 'data:image/png;base64,' + user.contactUser.photo;

                            const style = {
                                gridRowEnd: `span ${this.getProportion(user)}`
                                // backgroundImage: `url('${image}')`
                            };

                            return (
                                <>
                                    <figure className={"card"} style={style}>
                                        <CardCohabitation user={user}/>
                                    </figure>
                                    <br/>
                                </>
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