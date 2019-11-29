import React, { useState } from 'react'

import { accountService } from '../../services'

export function Login() {

  const [name, setName] = useState('')
  const [password, setPassword] = useState('')

  function login() {
    accountService.login(name, password).then(res => console.log('response', res))
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