import React from 'react'
import { BtnRemove, Container } from './styles'

const customPropsControledByAttacker = {
  dangerouslySetInnerHTML: {
    "__html": "isso ai<img onerror=alert('teste xss') src='invalid_url' />"
  }
}

export function Comments({ comments, onRemove }) {

  return (
    <Container>
      <div {...customPropsControledByAttacker} />
      {
        comments && comments.length ?
          comments.map(p => <div key={p.id + ''}>
            <span>{p.id} - </span>{p.description}<BtnRemove onClick={() => onRemove(p.id)}>Remove</BtnRemove>
          </div>)
          : null
      }
    </Container>
  )
}