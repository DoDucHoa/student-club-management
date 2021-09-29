import React from "react";

// React Router
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";

// material UI
import { ThemeProvider } from "@mui/material/styles";
import { theme } from "./Themes/index.js";

// Link component
import LoginForm from "./Pages/Authenticate/LoginForm";
import RegisterForm from "./Pages/Authenticate/RegisterForm";
import DashBoard from "./Pages/Dashboard/DashBoard";

function App() {
  return (
    <>
      <ThemeProvider theme={theme}>
        <Router>
          <Switch>
            <Route exact path="/" component={DashBoard} />
            <Route path="/login" component={LoginForm} />
            <Route path="/register" component={RegisterForm} />
          </Switch>
        </Router>
      </ThemeProvider>
    </>
  );
}

export default App;
