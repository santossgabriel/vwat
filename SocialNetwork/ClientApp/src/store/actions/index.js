export const UserActionTypes = {
    SET_USER: 'SET_USER'
}

export const setUser = user => ({ type: UserActionTypes.SET_USER, payload: user })