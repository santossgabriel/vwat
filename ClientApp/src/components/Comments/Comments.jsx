import React from 'react'
import { BtnRemove, Container } from './styles'

const customPropsControledByAttacker = {
  dangerouslySetInnerHTML: {
    "__html": "isso ai<img onerror=alert('teste') src='invalid_url' />"
  }
};

export function Comments({ comments, onRemove }) {

  return (
    <Container>
      <div {...customPropsControledByAttacker} />
      <a href="javascript:console.log('teste bombando!')">enviar</a>
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