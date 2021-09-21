import React, { useRef } from "react";

import { FormControl, ButtonControl, TextBoxControl } from "./Form";

const LoginForm = (props) => {
  const emailInputRef = useRef("");
  const passwordInputRef = useRef("");

  const submitHandler = (event) => {
    event.preventDefault();
    console.log(emailInputRef.current.value);
  };

  return (
    <FormControl onSubmit={submitHandler}>
      <h1>Welcome</h1>
      <TextBoxControl
        type="email"
        ref={emailInputRef}
        placeholder="Email"
        required
      />
      <TextBoxControl
        type="password"
        ref={passwordInputRef}
        placeholder="Password"
        required
      />

      <ButtonControl type="submit">sign in</ButtonControl>
      <p>Don't have an account?</p>
      <ButtonControl type="button" onClick={props.onClick}>
        sign up
      </ButtonControl>
    </FormControl>
  );
};

export default LoginForm;
