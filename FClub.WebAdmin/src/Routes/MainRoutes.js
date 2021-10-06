import DashBoardLayout from "../Layout/DashBoardLayout";
import LoginForm from "../Pages/Authenticate/LoginForm";

import ManageUserForm from "../Pages/ManageUser/ManageUserForm";

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
