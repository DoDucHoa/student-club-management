import React, { lazy } from "react";

// project import
import Loadable from "../Components/UI/Loadable";

import LoginForm from "../Pages/Authenticate/LoginForm";

const ManageUserForm = Loadable(
  lazy(() => import("../Pages/ManageUser/ManageUserForm"))
);
const DashBoardLayout = Loadable(
  lazy(() => import("../Layout/DashBoardLayout"))
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
