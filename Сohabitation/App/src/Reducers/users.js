/*
 Данные по умолчанию.
 */
const defaultState = [
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
    }
];

/*
Минимальное количество пользователей.
 */
const minCountUsers = 1;

/*
 Получение и сохранение всех пользователей. 
 */
export default function getAllUsers(state = defaultState, action) {
    if (action.type === 'GET_USERS' && state.length <= minCountUsers) {
        let buffer = state.concat(action.payload);

        if (sessionStorage.getItem('users') === 'undefined'
            || sessionStorage.getItem('users') === null) {
            sessionStorage.setItem('users', JSON.stringify(buffer));
        }

        return JSON.parse(sessionStorage.getItem('users'));
    }

    const def = sessionStorage.getItem('users');

    return def === 'undefined' ? state : JSON.parse(def);
} 