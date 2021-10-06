import React, { lazy } from "react";

// project import
import Loadable from "../Components/UI/Loadable";

import DashBoardLayout from "../Layout/DashBoardLayout";
import LoginForm from "../Pages/Authenticate/LoginForm";

const ManageUserForm = Loadable(
  lazy(() => import("../Pages/ManageUser/ManageUserForm"))
);

const MainRoutes = (isLoggedIn) => {
  return {
    path: "/",
    element: isLoggedIn ? <DashBoardLayout /> : <LoginForm />,
    children: [
      {
        path: "/",
        element: <ManageUserForm />,
      },
    ],
  };
};

export default MainRoutes;
