import styled from 'styled-components'

export const Container = styled.div`
    display: flex;
    justify-content: space-around;
    align-content: center;
    align-items: center;
    flex-direction: row;
    height: 70px;
    background-color: #333;
    box-shadow: 5px 5px 5px black;
    overflow: hidden;
    padding: 0 10px;
`

export const Title = styled.div`
    font-size: 30px;
    font-weight: bold;
    color: white;
`

export const BoxMenu = styled.div`
    font-size: 12px;
    font-weight: bold;
    color: white;
    input {
        width: 100px;
        font-size: 12px;
    }
`

export const BtnLoginLogout = styled.button`
    font-size: 10px;
`