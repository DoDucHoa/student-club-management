import React from "react";
import { makeStyles } from "@mui/styles";
import { TextField, Grid, Button, Link } from "@mui/material";

import * as Bi from "react-icons/bi";
import FormCard from "../../UI/FormCard";
import { useHistory } from "react-router";

const useStyles = makeStyles((theme) => ({
  bottom: {
    display: "flex",
    [theme.breakpoints.down("sm")]: {
      display: "block",
    },
  },
  btnBottom: {
    [theme.breakpoints.down("sm")]: {
      padding: 0,
      margin: 0,
    },
  },
}));

const LoginForm = () => {
  const classes = useStyles();
  const history = useHistory();

  const submitHandler = (event) => {
    event.preventDefault();
    history.push("/");
  };

  const onLinkClick = (event) => {
    event.preventDefault();
    history.push("/register");
  };

  return (
    <FormCard>
      <h1 style={{ letterSpacing: "5px" }}>Welcome to Cluber!</h1>
      <form onSubmit={submitHandler}>
        <Grid container spacing={3} direction="column">
          <Grid item>
            <TextField
              id="outlined-email"
              placeholder="Enter your email"
              label="Email"
              variant="standard"
              fullWidth
            />
          </Grid>
          <Grid item>
            <TextField
              id="outlined-password"
              label="Password"
              variant="standard"
              placeholder="Enter your password"
              fullWidth
            />
          </Grid>
          <Grid item>
            <Button
              onClick={submitHandler}
              variant="contained"
              size="large"
              fullWidth
              startIcon={<Bi.BiLogIn />}
            >
              Sign In
            </Button>
          </Grid>
        </Grid>
      </form>
      <div style={{ marginTop: "15px" }}>
        <Link href="#" underline="always">
          Forgot Password
        </Link>
      </div>
      <div className={classes.bottom}>
        <p style={{ fontWeight: "600", marginRight: "15px" }}>
          Don't have an account?
        </p>
        <Link
          onClick={onLinkClick}
          underline="none"
          className={classes.btnBottom}
          style={{ margin: "auto 0px" }}
        >
          Sign In
        </Link>
      </div>
    </FormCard>
  );
};

export default LoginForm;
