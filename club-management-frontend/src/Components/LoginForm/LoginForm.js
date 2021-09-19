import React from "react";
import { FormControl } from "./Form";

const LoginForm = (props) => {
  return (
    <FormControl>
      <h1>Welcome</h1>
      <input type="email" placeholder="Email" required />
      <input type="password" placeholder="Password" required />
      <button type="submit">sign in</button>
      <p>Don't have an account?</p>
      <button type="button" onClick={props.onClick}>
        sign up
      </button>
    </FormControl>
  );
};

export default LoginForm;
