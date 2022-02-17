import React, { Component } from 'react';


export class Home extends Component {
  static displayName = Home.name;

  constructor(props){
    super(props)
    
    // Set initial state
    this.state = { 
      searchWord: "",
      books: []}     
    // Binding this keyword
    this.handleClick = this.handleClick.bind(this)
    this.handleInputChange = this.handleInputChange.bind(this)
  }    

  handleInputChange(event) {
    const target = event.target;
    const value = target.value;

    this.setState({searchWord: value})
  }

  handleSubmit(event) {
    event.preventDefault();
  }

  async handleClick(){   
    // Changing state
    const result = await this.serachBookByWord(this.state.searchWord)
    this.setState(({
      books: result
    })) 
  }

  render () {  
    return (      
      <div>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css"></link>
        <form onSubmit={this.handleSubmit}>
          <input ref="search" type="text" placeholder="Искать здесь..." onChange={this.handleInputChange}/>
          <button type="submit" onClick={this.handleClick}></button>
        </form>
        <div id="search_box-result">
            {this.state.books.map((book) => (
              <li key={book}>{book}</li>
            ))}
        </div>
      </div>
    );
  }  

  async serachBookByWord(word){
    const searchParams = new URLSearchParams();
    searchParams.append("word", word)

    const response = await fetch('home?' + searchParams.toString());
    const data = await response.json();
    console.log(data)

    return data
  }
}


