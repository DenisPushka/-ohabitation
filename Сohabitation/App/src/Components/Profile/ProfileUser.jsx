import React, {Component} from 'react'
import Header from "../Header/Header";

// Профиль пользователя.
class ProfileUser extends Component{
    
    constructor(props) {
        super(props);
    }

    getProfile() {
        fetch("/api/User/GetAllUsers", {
            method: 'GET'
        })
            .then(res => res.json())
            .then(
                result => console.log("Получили данные", result)
            )
    }
    
    render() {
        return (
            <>
                <Header/>
            </>
        )
    }
}

export default ProfileUser