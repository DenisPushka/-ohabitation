import React, {Component} from 'react'

export class ProfileComponent extends Component{
    render() {
        this.getProfile()
        return (
            <div>
                Профиль
            </div>
        )
    }
    
    getProfile() {
        fetch("http://localhost:5490/coha")
            .then(res => res.json())
            .then(
                result => console.log("Получили данные", result)
            )
    }

}