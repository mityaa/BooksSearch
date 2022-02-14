import React, { Component } from 'react';
import { Routes, Route, Link } from "react-router-dom";
import { Home } from './components/Home';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <Route exact path='/' component={Home} />
    );
  }
}
