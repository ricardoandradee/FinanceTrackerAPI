import { AuthActions, SET_AUTHENTICATED, SET_UNAUTHENTICATED } from '../actions/auth.actions';

export interface State {
    isAuthenticated: boolean;
    userId: string;
}
const initialState: State = {
    isAuthenticated: false,
    userId: ""
};

export function authReducer(state = initialState, action: AuthActions) {
    switch (action.type) {
        case SET_AUTHENTICATED:
            return { isAuthenticated: true, userId: action.payload };
        case SET_UNAUTHENTICATED:
            return { isAuthenticated: false, userId: "" };
        default: { return state; }
    }
}

export const getIsAuth = (state: State) => state.isAuthenticated;
export const getUserId = (state: State) => state.userId;
