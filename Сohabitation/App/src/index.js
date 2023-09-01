import React from 'react';
import ReactDOM from 'react-dom';
import reducers from "./Reducers";
import thunk from "redux-thunk";
import {BrowserRouter, Route, Routes} from 'react-router-dom';
import {Provider} from "react-redux";
import {applyMiddleware, createStore} from "redux";
import {composeWithDevTools} from "redux-devtools-extension";
import './css/index.css';
import Home from "./Components/Home/Home";
import ProfileUser from "./Components/Profile/ProfileUser";
import CardCohabitation from "./Components/Cards/CardCohabitation";
import LogIn from "./Components/LogIn/LogIn";
import SignUp from "./Components/SignUp/SignUp";


const store = createStore(reducers, composeWithDevTools(applyMiddleware(thunk)));

// Роутер.
const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <Provider store={store}>
        <BrowserRouter>
            <Routes>
                <Route path="*" element={<Home/>}/>
                <Route path="/ProfileUser" element={<ProfileUser/>}/>
                <Route path="/Card" element={<CardCohabitation/>}/>
                <Route path="/LogIn" element={<LogIn/>}/>
                <Route path="/SignUp" element={<SignUp/>}/>
            </Routes>
        </BrowserRouter>
    </Provider>
);