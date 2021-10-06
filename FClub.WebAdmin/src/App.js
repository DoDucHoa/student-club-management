import React from "react";
import { theme } from "./Themes/index.js";

// material UI
import { ThemeProvider } from "@mui/material/styles";
import { CssBaseline } from "@mui/material";

// Link component
import Routes from "./Routes";
import NavigationScroll from "./Layout/NavigationScroll";

function App() {
  return (
    <>
      <ThemeProvider theme={theme}>
        <CssBaseline />
        <NavigationScroll>
          <Routes />
        </NavigationScroll>
      </ThemeProvider>
    </>
  );
}

export default App;

//         <Switch>
//           <Route exact path="/">
//             {isLoggedIn && <Redirect to="/manage-user" />}
//             {!isLoggedIn && <Redirect to="/login" />}
//           </Route>
//           <Route path="/login">
//             <LoginForm />
//           </Route>
//           <Route path="/register">
//             <RegisterForm />
//           </Route>
//           <DashBoardLayout>
//             <Route path="/manage-user">
//               {isLoggedIn && <ManageUserForm />}
//               {!isLoggedIn && <Redirect to="/login" />}
//             </Route>
//           </DashBoardLayout>
//           <Route path="*">
//             <Redirect to="/" />
//           </Route>
//         </Switch>
