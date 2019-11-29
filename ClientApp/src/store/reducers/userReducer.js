import { UserActionTypes } from '../actions'
import { storageService } from '../../services'

const INITIAL_STATE = storageService.getUser() || {}

export const userReducer = (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case UserActionTypes.SET_USER:
            storageService.setUser(action.payload)
            return action.payload || {}
        default:
            return state
    }
}