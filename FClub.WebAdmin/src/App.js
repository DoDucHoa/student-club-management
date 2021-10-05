import React from "react";
import { theme } from "./Themes/index.js";

// context
import { useSelector } from "react-redux";

// React Router
import { Route, Switch, Redirect } from "react-router-dom";

// material UI
import { ThemeProvider } from "@mui/material/styles";
import { CssBaseline } from "@mui/material";

// Link component
import LoginForm from "./Pages/Authenticate/LoginForm";
import RegisterForm from "./Pages/Authenticate/RegisterForm";
import ManageUserForm from "./Pages/ManageUser/ManageUserForm.js";
import DashBoardLayout from "./Layout/DashBoardLayout.js";

function App() {
  const isLoggedIn = useSelector((state) => state.auth.isLoggedIn);

  return (
    <>
      <ThemeProvider theme={theme}>
        <CssBaseline />
        <Switch>
          <Route exact path="/">
            {isLoggedIn ? (
              <Redirect to="/manage-user" />
            ) : (
              <Redirect to="/login" />
            )}
          </Route>
          <Route path="/login" component={LoginForm} />
          <Route path="/register" component={RegisterForm} />
          <DashBoardLayout>
            <Route path="/manage-user">
              {isLoggedIn ? <ManageUserForm /> : <Redirect to="/login" />}
            </Route>
          </DashBoardLayout>
        </Switch>
      </ThemeProvider>
    </>
  );
}

export default App;
