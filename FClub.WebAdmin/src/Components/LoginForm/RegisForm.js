import React, { useState } from "react";

import {
  FormControl,
  ButtonControl,
  TextBoxControl,
  RePasswordInput,
} from "./Form";

const RegisForm = (props) => {
  const [password, setPassword] = useState("");
  const [repassword, setRepassword] = useState("");

  const submitHandler = () => {
    console.log(1);
  };

  const passwordChangeHandler = (event) => {
    setPassword(event.target.value);
  };

  const repasswordChangeHandler = (event) => {
    setRepassword(event.target.value);
  };

  return (
    <FormControl onSubmit={submitHandler}>
      <h1>sign up</h1>
      <TextBoxControl type="email" placeholder="Email" required />
      <TextBoxControl type="text" placeholder="Full Name" required />
      <TextBoxControl type="tel" placeholder="Phone" />
      <TextBoxControl
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
      <ButtonControl type="submit">Register</ButtonControl>
      <p>Already have an account?</p>
      <ButtonControl type="button" onClick={props.onClick}>
        sign in
      </ButtonControl>
    </FormControl>
  );
};

export default RegisForm;
