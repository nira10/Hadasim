import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { Provider } from 'react-redux';
import { createStore, combineReducers } from 'redux';
import MembersReducer from './store/reducers/MembersReducer'
import VaccinationsReducer from './store/reducers/VaccinationsReducer';
import ProducerReducer from './store/reducers/ProducerReducer';


const root = ReactDOM.createRoot(document.getElementById('root'));
const x= createStore(combineReducers({patient: MembersReducer, vaccine: VaccinationsReducer,prod: ProducerReducer}))

root.render(
  <Provider store={x}>
    <App />
    </Provider>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
