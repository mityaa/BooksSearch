import React, { Component } from 'react';
import { Routes, Route, Link } from "react-router-dom";
import { Provider } from 'react-redux';
import { createStore, compose, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';

import { rootReducer } from './redux/rootReducer';
import Home from './components/Home';
import './custom.css'

const store = createStore(rootReducer, compose(
  applyMiddleware(thunk)), 
  window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
); 

function App (){
  return (
  <Provider store={store}>
  <Route exact path='/' component={Home} />
</Provider>
  )
}



export default App;