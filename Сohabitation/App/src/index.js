import React from 'react';
import ReactDOM from 'react-dom';
import {BrowserRouter, Route, Routes} from 'react-router-dom';
import './css/index.css';
import Home from "./Components/Home/Home";
import ProfileUser from "./Components/Profile/ProfileUser";
import CardCohabitation from "./Components/Cards/CardCohabitation";
import LogIn from "./Components/LogIn/LogIn";
import SignUp from "./Components/SignUp/SignUp";


// Роутер.
const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    // <React.StrictMode>
    // <Provider store={store}>
    <BrowserRouter>
        <Routes>
            <Route path="*" element={<Home/>}/>
            <Route path="/ProfileUser" element={<ProfileUser/>}/>
            <Route path="/Card" element={<CardCohabitation/>}/>
            <Route path="/LogIn" element={<LogIn/>}/>
            <Route path="/SignUp" element={<SignUp/>}/>
        </Routes>
    </BrowserRouter>
    // </Provider>
    /*</React.StrictMode>*/
);