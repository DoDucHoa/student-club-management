import React, { lazy } from "react";
import { useRoutes, Navigate } from "react-router-dom";
import { useSelector } from "react-redux";

import LoginForm from "../Pages/Authenticate/LoginForm";
import RegisterForm from "../Pages/Authenticate/RegisterForm";

// component
import Loadable from "../Components/UI/Loadable";
import Page404 from "../Pages/Page404";

// routes
const ManageUserPage = Loadable(
  lazy(() => import("../Pages/ManageUser/MangageUserPage"))
);
const DashBoardLayout = Loadable(lazy(() => import("../Layout/MainLayout")));

export default function ThemeRoutes() {
  const isLoggedIn = useSelector((state) => state.auth.isLoggedIn);

  return useRoutes([
    {
      path: "/",
      children: [
        {
          element: isLoggedIn ? (
            <Navigate to="/dashboard" replace />
          ) : (
            <Navigate to="/login" replace />
          ),
        },
        {
          path: "login",
          element: <LoginForm />,
        },
        {
          path: "register",
          element: <RegisterForm />,
        },
        { path: "404", element: <Page404 /> },
      ],
    },
    {
      path: "/dashboard",
      element: isLoggedIn ? (
        <DashBoardLayout />
      ) : (
        <Navigate to="/login" replace />
      ),
      children: [
        { element: <Navigate to="/dashboard/user" replace /> }, // if url is blank (path: "") then redirect to /app
        {
          path: "user",
          element: <ManageUserPage />,
        },
      ],
    },
    { path: "*", element: <Navigate to="/404" replace /> },
  ]);
}
