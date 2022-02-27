import React from 'react';
import { searchWord } from '../redux/actions';
import { connect } from 'react-redux';

function Home(props) {
  return (
    <div>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css"></link>
    <form>
      <input ref="search" type="text" placeholder="Search here..." onChange={this.handleInputChange}/>
      <button type="submit" onClick={props.searchWord}></button>
    </form>
    <div id="search_box-result">
        {props.books.map((book) => (
          <li key={book}>{book}</li>
        ))}
    </div>
  </div>
  )
}

function mapStateToProps(state) {
  const { searchReducer } = state;
  return {
    books: searchReducer.books
  }
}

function mapDispatchToProps(dispatch) {
  return {
    searchWord: (word) => {
      return dispatch(searchWord(word));
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(Home);