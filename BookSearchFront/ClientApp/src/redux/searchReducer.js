import { SEARCH, SEARCH_RESET } from './types';

const initialState = {
    books: []
}

export const searchReducer = (state = initialState, action) => {
    switch(action.type) {
        case SEARCH:
            return {
                ...state,
                books: [...state.books, action.data]
            }
        case SEARCH_RESET:
            return initialState;
        default:
             return state;
    }
}