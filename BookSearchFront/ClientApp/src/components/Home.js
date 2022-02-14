import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (      
      <div>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css"></link>
        <form>
          <input type="text" placeholder="Искать здесь..."/>
          <button type="submit"></button>
        </form>
      </div>
    );
  }
}
