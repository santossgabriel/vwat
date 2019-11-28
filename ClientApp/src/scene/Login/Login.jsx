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
      <br />
      <span>Name:</span>
      <input onChange={e => setName(e.target.value)} />
      <br />
      <span>Password:</span>
      <input onChange={e => setPassword(e.target.value)} />
      <br />
      <button disabled={!name || !password} onClick={() => login()}>LOGIN</button>
    </div >
  )
}