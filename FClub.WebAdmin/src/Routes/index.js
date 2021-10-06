import { useRoutes } from "react-router-dom";
import { useSelector } from "react-redux";
// routes
// import MainRoutes from "./MainRoutes";
import { SignInRoute, SignUpRoute } from "./AuthenticationRoutes";
import MainRoutes from "./MainRoutes";

export default function ThemeRoutes() {
  const isLoggedIn = useSelector((state) => state.auth.isLoggedIn);

  return useRoutes([SignInRoute, SignUpRoute, MainRoutes(isLoggedIn)]);
}
