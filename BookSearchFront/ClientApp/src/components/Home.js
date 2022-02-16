import React, { Component } from 'react';


export class Home extends Component {
  static displayName = Home.name;

  constructor(props){
    super(props)
    
    // Set initial state
    this.state = { avengers: []}     
    // Binding this keyword
    this.handleClick = this.handleClick.bind(this)
  }    

  handleSubmit(event) {
    event.preventDefault();
  }

  handleClick(){   
    // Changing state
    this.setState(({
      avengers: this.getDataList()
    }))
  }

  getDataList(){
    var avengers = [ 'Iron Man', 'Captain America', 'Hulk', 'Thor', 'HawkEye'] // or query
    return avengers
  }

  render () {  
    return (      
      <div>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css"></link>
        <form onSubmit={this.handleSubmit}>
          <input type="text" placeholder="Искать здесь..."/>
          <button type="submit" onClick={this.handleClick}></button>
        </form>
        <div id="search_box-result">
            {this.state.avengers.map((avenger) => (
              <li>{avenger}</li>
            ))}
        </div>
      </div>
    );
  }  

  async serachBookByWord(word){
    const response = await fetch('home');
    const data = await response.json();
  }
}


