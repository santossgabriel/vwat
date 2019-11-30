import React, { useState } from 'react'
import { useSelector, useDispatch } from 'react-redux'

import { Container, Title, BoxMenu, BtnLoginLogout } from './styles'

import { accountService } from '../../services'
import { setUser } from '../../store/actions'

export function Toolbar() {

    const [name, setName] = useState('')
    const [password, setPassword] = useState('')
    const [error, setError] = useState(false)

    const dispatch = useDispatch()

    function login() {
        setError(false)
        accountService.login(name, password)
            .then(res => dispatch(setUser({ ...res.user, token: res.token })))
            .catch(err => setError(true))
    }

    const user = useSelector(state => state.user)

    return (
        <Container>
            <Title>Vulnerable Web Application for Testing</Title>
            <BoxMenu>
                {
                    user && user.email ?
                        <div>
                            <span>Logged: {user.email} </span>
                            <BtnLoginLogout onClick={() => dispatch(setUser(null))} className="btn">LOGOUT</BtnLoginLogout>
                        </div>
                        :
                        <div className="form-group">
                            <span hidden={!error} style={{ color: '#F66' }}>*</span>
                            <input onChange={e => { setName(e.target.value); setError(false) }} placeholder="Name" />
                            <input onChange={e => { setPassword(e.target.value); setError(false) }} placeholder="Password" type="password" />
                            <BtnLoginLogout className="btn" disabled={!name || !password} onClick={() => login()}>LOGIN</BtnLoginLogout>
                        </div>
                }
            </BoxMenu>
        </Container>
    )
}