// Данные по умолчанию.
const initialState = [
    {
        login: '',
        password: ''
    }
];

// Создание пользователя.
export default function createUsers(state = initialState, action) {
    if (action.type === 'ADD_USER') {
        if (sessionStorage.getItem('user') === 'undefined' || sessionStorage.getItem('user') === null) {
            sessionStorage.setItem('user', JSON.stringify(action.payload));
        } else {
            const userAuthentication = JSON.parse(sessionStorage.getItem('user'));
            
            if (action.payload.login !== userAuthentication.login) {
                sessionStorage.setItem('user', JSON.stringify(action.payload));
            }
        }
        
        return JSON.parse(sessionStorage.getItem('user'));
    }

    if (action.type === 'UPDATE_USER') {
        sessionStorage.setItem('user', JSON.stringify(action.payload));
    }

    const def = sessionStorage.getItem('user');
    
    return def === 'undefined' ? {login: '', password: ''} : JSON.parse(def);
}