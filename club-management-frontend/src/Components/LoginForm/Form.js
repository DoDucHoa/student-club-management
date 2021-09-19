import React, { useState } from "react";
import styled from "styled-components";

import LoginForm from "./LoginForm";
import RegisForm from "./RegisForm";

export const FormControl = styled.form`
  margin: 10rem auto;
  width: 30rem;
  text-align: center;
  padding: 2rem;
  background: #e6f3fa;
  border-radius: 25px;
  box-shadow: 0 1px 8px rgba(0, 0, 0, 0.25);

  @media (max-width: 768px) {
    width: 18rem;
    margin: 5rem auto;
  }

  & h1 {
    text-transform: uppercase;
    letter-spacing: 4px;
    font-weight: 800;
  }

  & p {
    font-weight: 600;
  }

  & input {
    border: 2px solid #89cff0;
    display: block;
    text-align: center;
    margin: 0.5rem auto;
    padding: 0.5rem;
    border-radius: 20px;
    outline: none;
    width: 13rem;
    color: black;
    max-width: 90%;
    transition: 0.25s;
  }

  & input:hover {
    width: 18rem;
    border-color: #85d4ca;
  }

  & input:focus {
    width: 18rem;
    border-color: #85d4ca;
  }

  & button {
    border: 2px solid #059dc0;
    background: #059dc0;
    display: block;
    text-align: center;
    margin: 0.5rem auto;
    padding: 0.5rem;
    border-radius: 20px;
    width: 12rem;
    color: white;
    text-transform: uppercase;
    box-shadow: 0 1px 8px rgba(0, 0, 0, 0.25);
    transition: 0.25s;
  }

  & button:hover {
    width: 15rem;
    color: white;
    border-color: #00a8a8;
    background: #00a8a8;
  }
`;

const Footer = styled.footer`
  & p {
    text-align: center;
    font-weight: 600;
  }
`;

const Form = () => {
  const [isLogin, setIsLogin] = useState(true);

  const changeFormHandler = () => {
    setIsLogin((prev) => (prev ? false : true));
  };

  return (
    <div>
      {isLogin ? (
        <LoginForm onClick={changeFormHandler} />
      ) : (
        <RegisForm onClick={changeFormHandler} />
      )}
      <Footer>
        <p>Copyright &copy; {new Date().getFullYear()}</p>
      </Footer>
    </div>
  );
};

export default Form;
