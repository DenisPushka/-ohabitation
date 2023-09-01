import {combineReducers} from 'redux';
import {routerReducer} from 'react-router-redux'

import user from './user'
import users from './users'

export default combineReducers({
    routing: routerReducer,
    // Нужно для пользователя, который входит в систему.
    user,
    // Нужно для отображения всех пользователей, без лишних запросов в бд.
    users
});