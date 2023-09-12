import {Component} from "react";
import Header from "../Header/Header";
import {Nav} from "react-bootstrap";
import {connect} from "react-redux";
import md5 from 'md5';
import "./Login.css";
import Crypto from "../../crypto";

// Авторизация.
class LogIn extends Component {

    state = {
        // Данные пользователя для входа в систему. 
        user: {
            // Логин.
            login: '',
            // Пароль.
            password: ''
        }
    };

    constructor(props) {
        super(props);

        this.updateLogin = this.updateLogin.bind(this);
        this.updatePassword = this.updatePassword.bind(this);
        this.checkLogIn = this.checkLogIn.bind(this);
    }

    /**
     * Изменение логина для авторизации.
     * */
    async updateLogin(event) {
        await event.preventDefault();
        this.setState({user: {...this.state.user, login: event.target.value}});
    }

    /**
     * Изменение пароля для авторизации.
     * */
    async updatePassword(event) {
        await event.preventDefault();
        this.setState({user: {...this.state.user, password: event.target.value}});
    }

    /**
     * Проверка входа;
     * При успехе - выход на домашнюю страницу, с сохраненной авторизацией;
     * При не уадче - вывод сообщения: "Неправильно введен логин или пароль".
     * */
    async checkLogIn(event) {
        await event.preventDefault();

        let form = new FormData();

        form.append('login', new Crypto().decryptStringAes(this.state.user.login));
        form.append('password', md5(this.state.user.password));//new Crypto().decryptStringAes(this.state.user.password));

        fetch("/api/User/Authorization", {
            method: 'POST',
            body: form
        })
            .then(res => {
                res.json().then(async (data) => {
                    if (data.contactUser === null) {
                        alert('Неправильно введен логин или пароль!');
                        return;
                    } else if (data === 'Permission denied!') {
                        window.location = '/';
                    }

                    await this.props.onAddUser(data);
                    window.location = '/';
                });
            });
    }

    render() {
        return (
            <>
                <Header/>

                <div className={'down_all'}>
                    <div className="containerAuthorization down_all">
                        <div className="form-container sign-in-container">
                            <div className="social-container">
                                <form>
                                    <h1 className={"h1_authorization"}>Вход</h1>

                                    <div className="form-group move_right">
                                        <label htmlFor="exampleInputEmail1">Email</label>
                                        <input
                                            type="email"
                                            className="form-control"
                                            id="exampleInputEmail1"
                                            aria-describedby="emailHelp"
                                            placeholder="Enter email"
                                            onChange={this.updateLogin}
                                        />

                                    </div>
                                    <div className="form-group move_right">
                                        <label htmlFor="exampleInputPassword1">Password</label>

                                        <input
                                            type="password"
                                            className="form-control"
                                            id="exampleInputPassword1"
                                            placeholder={"Password"}
                                            onChange={this.updatePassword}
                                        />
                                    </div>

                                    <button
                                        type="submit"
                                        className="btn btn-outline-danger button_enter"
                                        onClick={this.checkLogIn}>
                                        Войти
                                    </button>

                                    <Nav.Link
                                        type="submit"
                                        className="btn btn-outline-success button_authorization"
                                        href="/SignUp">
                                        Зарегистрироваться
                                    </Nav.Link>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </>
        );
    }
}

export default connect(
    state => ({
        user: state.user
    }),
    dispatch => ({
        onAddUser: (user) => {
            dispatch({type: 'ADD_USER', payload: user});
        }
    })
)(LogIn);