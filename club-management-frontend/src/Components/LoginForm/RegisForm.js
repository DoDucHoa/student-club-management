import React, { useState } from "react";
import styled from "styled-components";
import { FormControl } from "./Form";

const RePasswordInput = styled.input`
  border-color: ${(props) =>
    props.value != props.prevPass ? "red" : "#89cff0"} !important;
`;

const RegisForm = (props) => {
  const [password, setPassword] = useState("");
  const [repassword, setRepassword] = useState("");

  const onSubmitHandler = () => {
    console.log(1);
  };

  const passwordChangeHandler = (event) => {
    setPassword(event.target.value);
  };

  const repasswordChangeHandler = (event) => {
    setRepassword(event.target.value);
  };

  return (
    <FormControl onSubmit={onSubmitHandler}>
      <h1>sign up</h1>
      <input type="email" placeholder="Email" required />
      <input type="text" placeholder="Full Name" required />
      <input type="tel" placeholder="Phone" />
      <input
        type="password"
        value={password}
        onChange={passwordChangeHandler}
        placeholder="Password"
        required
      />
      <RePasswordInput
        type="password"
        placeholder="Re-enter Password"
        value={repassword}
        prevPass={password}
        onChange={repasswordChangeHandler}
        required
      />
      <button type="submit">Register</button>
      <p>Already have an account?</p>
      <button type="button" onClick={props.onClick}>
        sign in
      </button>
    </FormControl>
  );
};

export default RegisForm;
