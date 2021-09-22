import React, { useState, useEffect } from "react";

import {
  FormControl,
  ButtonControl,
  TextBoxControl,
  RePasswordInput,
} from "./Form";

const RegisForm = (props) => {
  const [password, setPassword] = useState("");
  const [repassword, setRepassword] = useState("");
  const [repasswordIsValid, setRepasswordIsValid] = useState(null);

  useEffect(() => {
    setRepasswordIsValid(password === repassword);
  }, [password, repassword]);

  const passwordChangeHandler = (event) => {
    setPassword(event.target.value);
  };

  const repasswordChangeHandler = (event) => {
    setRepassword(event.target.value);
  };

  const submitHandler = () => {
    console.log(1);
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
        onChange={repasswordChangeHandler}
        isValid={repasswordIsValid}
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
