import { SEARCH } from './types';

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

            default:
                return state;
    }
}