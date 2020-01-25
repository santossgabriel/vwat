import React, { useState, useEffect } from 'react'

import { commentService } from '../../services'
import { Comments } from '../../components'

export function XssStored() {

  const [comment, setComment] = useState('')
  const [comments, setComments] = useState('')

  useEffect(() => {
    refresh()
  }, [])

  function sendComment() {
    setComment('')
    commentService.add(comment)
      .then(res => refresh())
      .catch(err => console.log(err))
  }

  function refresh() {
    commentService.get().then(res => setComments(res))
  }

  function remove(id) {
    commentService.remove(id)
      .then(res => refresh())
      .catch(err => console.log(err))
  }

  return (
    <div>
      <h4>Xss Stored</h4>
      <br />
      <br />
      <input value={comment} onChange={e => setComment(e.target.value)} />
      <br />
      <br />
      <button disabled={!comment} onClick={() => sendComment()}>SEND COMMENT</button>
      <br />
      <br />
      <Comments onRemove={id => remove(id)} comments={comments} />
    </div>
  )
}