import React, { lazy } from "react";
import { useRoutes, Navigate } from "react-router-dom";
import { useSelector } from "react-redux";

import LoginForm from "../Pages/Authenticate/LoginForm";
import RegisterForm from "../Pages/Authenticate/RegisterForm";

// component
import Loadable from "../Components/UI/Loadable";
import Page404 from "../Pages/Page404";

// routes
/// layout ///
const DashBoardLayout = Loadable(lazy(() => import("../Layout/MainLayout")));

/// page ///
const ProfilePage = Loadable(
  lazy(() => import("../Pages/Profile/ProfilePage"))
);

const ManageUserPage = Loadable(
  lazy(() => import("../Pages/ManageUser/MangageUserPage"))
);

const ManageClubPage = Loadable(lazy(() => import("../Pages/Club/ClubPage")));

const ActivityPage = Loadable(
  lazy(() => import("../Pages/Activities/ActivityPage"))
);

const AdditionalForm = Loadable(
  lazy(() => import("../Pages/Authenticate/AdditionalForm"))
);

// -----------------------------------------------------------------------------
export default function ThemeRoutes() {
  const isRegistered = useSelector((state) => state.auth.isRegistered);
  const isLoggedIn = useSelector((state) => state.auth.isLoggedIn);

  const render = () => {
    if (isRegistered) {
      if (isLoggedIn) {
        return <Navigate to="/dashboard" replace />;
      } else {
        return <Navigate to="/login" replace />;
      }
    } else {
      return <Navigate to="/additional-info" />;
    }
  };

  return useRoutes([
    {
      path: "/",
      children: [
        {
          element: render(),
        },
        {
          path: "login",
          element: <LoginForm />,
        },
        {
          path: "register",
          element: <RegisterForm />,
        },
        {
          path: "additional-info",
          element: <AdditionalForm />,
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
        { element: <Navigate to="/dashboard/club" replace /> }, // if url is blank (path: "") then redirect to /app
        {
          path: "club",
          element: <ManageClubPage />,
        },
        {
          path: "user",
          element: <ManageUserPage />,
        },
        {
          path: "activity",
          element: <ActivityPage />,
        },
      ],
    },
    {
      path: "/user",
      element: isLoggedIn ? (
        <DashBoardLayout />
      ) : (
        <Navigate to="/login" replace />
      ),
      children: [
        { element: <Navigate to="/user/profile" replace /> }, // if url is blank (path: "") then redirect to /app
        {
          path: "profile",
          element: <ProfilePage />,
        },
      ],
    },
    { path: "*", element: <Navigate to="/404" replace /> },
  ]);
}
