import React, { useRef } from "react";
import { FormControl } from "./Form";

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
      <input type="email" ref={emailInputRef} placeholder="Email" required />
      <input
        type="password"
        ref={passwordInputRef}
        placeholder="Password"
        required
      />
      <button type="submit">sign in</button>
      <p>Don't have an account?</p>
      <button type="button" onClick={props.onClick}>
        sign up
      </button>
    </FormControl>
  );
};

export default LoginForm;
