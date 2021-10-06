import React from "react";

import RegisterForm from "../Pages/Authenticate/RegisterForm";
import LoginForm from "../Pages/Authenticate/LoginForm";

export const SignInRoute = {
  path: "/login",
  element: <LoginForm />,
};

export const SignUpRoute = {
  path: "/register",
  element: <RegisterForm />,
};
