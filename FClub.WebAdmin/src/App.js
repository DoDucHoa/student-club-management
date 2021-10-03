import React from "react";
import { theme } from "./Themes/index.js";

// React Router
import { Route, Switch } from "react-router-dom";

// material UI
import { ThemeProvider } from "@mui/material/styles";
import { CssBaseline } from "@mui/material";

// Link component
import LoginForm from "./Pages/Authenticate/LoginForm";
import RegisterForm from "./Pages/Authenticate/RegisterForm";
import ManageUserForm from "./Pages/ManageUser/ManageUserForm.js";
import DashBoardLayout from "./Layout/DashBoardLayout.js";

function App() {
  return (
    <>
      <ThemeProvider theme={theme}>
        <CssBaseline />
        <Switch>
          <Route exact path="/" component={LoginForm} />
          <Route path="/login" component={LoginForm} />
          <Route path="/register" component={RegisterForm} />
          <DashBoardLayout>
            <Route path="/manage-user" component={ManageUserForm} />
          </DashBoardLayout>
        </Switch>
      </ThemeProvider>
    </>
  );
}

export default App;
