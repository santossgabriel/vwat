import React, { useState } from 'react'
import { useDispatch } from 'react-redux'

import { accountService } from '../../services'
import { setUser } from '../../store/actions'

export function Login() {

  const [name, setName] = useState('')
  const [password, setPassword] = useState('')

  const dispatch = useDispatch()

  function login() {
    accountService.login(name, password)
      .then(res => dispatch(setUser({ ...res.user, token: res.token })))
      .catch(err => console.log(err))
  }

  return (
    <div>
      <h3>Login</h3>
      <div className="form-group">
        <span>Name:</span>
        <input onChange={e => setName(e.target.value)} />
      </div>
      <div className="form-group">
        <span>Password:</span>
        <input onChange={e => setPassword(e.target.value)} />
      </div>
      <button className="btn" disabled={!name || !password} onClick={() => login()}>LOGIN</button>
    </div >
  )
}