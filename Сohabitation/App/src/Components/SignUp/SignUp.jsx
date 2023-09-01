import {Component} from "react";
import Header from "../Header/Header";

// Регистрация.
class SignUp extends Component {

    state = {
        // Новый пользователь.
        newUser: {
            // Минимальное количество, которое готов платить пользователь.
            minMoney: 0,
            // Максимальное количество, которое готов платить пользователь.
            maxMoney: 0,
            // Логин.
            login: '',
            // Пароль.
            password: '',
            // Контактная информация о пользователе.
            contactUser: {
                // Имя.
                name: '',
                // Фамилия.
                lastname: '',
                // Отчество.
                patronymic: '',
                // Город.
                city: {
                    cityId: null,
                    // Название.
                    name: ''
                },
                // Курс обучения (по умолчанию 0).
                course: 0,
                // Дата рождения.
                dateBirthday: '',
                // Район проживания.
                district: {
                    districtId: null,
                    // Название.
                    name: ''
                },
                // Почта.
                email: '',
                // Пол.
                gender: '',
                // Ссылка на вк.
                linkVk: '',
                // Ссылка на ТГ.
                linkTelegram: '',
                // Телефон.
                phone: '',
                // Университет.
                university: {
                    universityId: null,
                    // Название.
                    name: ''
                },
                // Возраст. (Вносить не надо, высчитывается в бизнес логике).
                age: 0,
                // Фото (массив байт).
                photo: null,
                // Описание.
                description: ''
            }
        }
    };

    constructor(props) {
        super(props);
        
        this.changeName = this.changeName.bind(this);
        this.changeLastname = this.changeLastname.bind(this);
        this.changePatronymic = this.changePatronymic.bind(this);
        this.changeLogin = this.changeLogin.bind(this);
        this.changePassword = this.changePassword.bind(this);
        this.changeMinMoney = this.changeMinMoney.bind(this);
        this.changeMaxMoney = this.changeMaxMoney.bind(this);
        this.changeCity = this.changeCity.bind(this);
        this.changeDistrict = this.changeDistrict.bind(this);
        this.changeUniversity = this.changeUniversity.bind(this);
        this.changeCourse = this.changeCourse.bind(this);
        this.changeEmail = this.changeEmail.bind(this);
        this.changePhone = this.changePhone.bind(this);
        this.changePhoto = this.changePhoto.bind(this);
        this.changeGender = this.changeGender.bind(this);
        this.changeDateBirthday = this.changeDateBirthday.bind(this);
        this.changeDescription = this.changeDescription.bind(this);
        this.changeLinkVk = this.changeLinkVk.bind(this);
        this.changeLinkTelegram = this.changeLinkTelegram.bind(this);
    }

    // Обработка ввода имени.
    async changeName(event) {
        await event.preventDefault();
        await this.setState({newUser: {...this.state.newUser.contactUser, name: event.target.value}});
    }

    // Обработка ввода фамилии.
    async changeLastname(event) {
        await event.preventDefault();
        await this.setState({newUser: {...this.state.newUser.contactUser, lastname: event.target.value}});
    }

    // Обработка ввода отчества.
    async changePatronymic(event) {
        await event.preventDefault();
        await this.setState({newUser: {...this.state.newUser.contactUser, patronymic: event.target.value}});
    }

    // Обработка ввода минимальной платы за жилье.
    async changeMinMoney(event) {
        await event.preventDefault();
        await this.setState({newUser: {...this.state.newUser, minMoney: event.target.value}});
    }

    // Обработка ввода максимальной платы за жилье.
    async changeMaxMoney(event) {
        await event.preventDefault();
        await this.setState({newUser: {...this.state.newUser, maxMoney: event.target.value}});
    }

    // Обработка ввода логина.
    async changeLogin(event) {
        await event.preventDefault();
        await this.setState({newUser: {...this.state.newUser, login: event.target.value}});
    }

    // Обработка ввода пароль.
    async changePassword(event) {
        await event.preventDefault();
        await this.setState({newUser: {...this.state.newUser, password: event.target.value}});
    }

    // Обработка ввода даты рождения.
    async changeDateBirthday(event) {
        await event.preventDefault();
        await this.setState({newUser: {...this.state.newUser.contactUser, dateBirthday: event.target.value}});
    }

    // Обработка ввода пола.
    async changeGender(event) {
        await event.preventDefault();
        await this.setState({newUser: {...this.state.newUser.contactUser, gender: event.target.value}});
    }

    // Обработка ввода города.
    async changeCity(event) {
        await event.preventDefault();
        await this.setState({newUser: {...this.state.newUser.contactUser.city, cityId: event.target.value}});
    }

    // Обработка ввода район проживания.
    async changeDistrict(event) {
        await event.preventDefault();
        await this.setState({newUser: {...this.state.newUser.contactUser.district, districtId: event.target.value}});
    }

    // Обработка ввода университета.
    async changeUniversity(event) {
        await event.preventDefault();
        await this.setState({newUser: {...this.state.newUser.contactUser.university, universityId: event.target.value}});
    }
    
    // Обработка ввода курса обучения.
    async changeCourse(event) {
        await event.preventDefault();
        await this.setState({newUser: {...this.state.newUser.contactUser,  course: event.target.value}});
    }

    // Обработка ввода телефона.
    async changePhone(event) {
        await event.preventDefault();
        await this.setState({newUser: {...this.state.newUser.contactUser, phone: event.target.value}});
    }
    
    // Обработка ввода ссылки на ВК.
    async changeLinkVk(event) {
        await event.preventDefault();
        await this.setState({newUser: {...this.state.newUser.contactUser, linkVk: event.target.value}});
    }
    
    // Обработка ввода ссылки на ТГ.
    async changeLinkTelegram(event) {
        await event.preventDefault();
        await this.setState({newUser: {...this.state.newUser.contactUser, linkTelegram: event.target.value}});
    }
    
    // Обработка ввода фото.
    async changePhoto(event) {
        await event.preventDefault();
        await this.setState({newUser: {...this.state.newUser.contactUser, photo: event.target.value}});
    }
    
    // Обработка ввода почта.
    async changeEmail(event) {
        await event.preventDefault();
        await this.setState({newUser: {...this.state.newUser.contactUser, email: event.target.value}});
    }
    
    // Обработка ввода описания.
    async changeDescription(event) {
        await event.preventDefault();
        await this.setState({newUser: {...this.state.newUser.contactUser, description: event.target.value}});
    }


    render() {
        return (
            <>
                <Header/>
            </>
        );
    }
}

export default SignUp;