import React, { useState, useRef } from 'react';
import { searchWord } from '../redux/actions';
import { connect, useSelector, useDispatch } from 'react-redux';
import { errorFallback } from '../helpers/errorFallback';
import { ErrorBoundary } from 'react-error-boundary';

  
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

function Home(props) {  
  const [wordToSearch, setSearchWord] = useState('');
  const dispatch = useDispatch();   

  const books = useSelector(state => {
      const { searchReducer } = state;
      return searchReducer.books;
  });

  const handleSubmit = (e) => {
    e.preventDefault();
    dispatch(searchWord(wordToSearch));
  }
  
  const handleInputChange = (e) => {
    setSearchWord(e.target.value);
  }  

  const inputRef = useRef(null)

  return (
  <div>
    <ErrorBoundary FallbackComponent={errorFallback} onReset={() => setSearchWord('')}>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css"></link>
    <form onSubmit={handleSubmit}>
      <input ref={inputRef} type="text" placeholder="Search here..." onChange={handleInputChange}/>
      <button type="submit"></button>
    </form>
    <div id="search_box-result">
      {books.map((book) => (
          <li key={book}>
            {book}
            </li>
        ))}
    </div>
    </ErrorBoundary>
  </div>
  )
}

export default connect(mapStateToProps, mapDispatchToProps)(Home);