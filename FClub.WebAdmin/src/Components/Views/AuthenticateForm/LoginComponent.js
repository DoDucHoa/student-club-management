import React from "react";

import { makeStyles } from "@mui/styles";
import { TextField, Grid, Button, Link } from "@mui/material";

import { BiLogIn } from "react-icons/bi";
import FormCard from "../../UI/FormCard";
import { useHistory } from "react-router";
import { motion } from "framer-motion";

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
    history.push("/manage-user");
  };

  const onLinkClick = (event) => {
    event.preventDefault();
    history.push("/register");
  };

  return (
    <FormCard>
      <motion.h1
        initial={{ fontSize: "0px" }}
        animate={{ letterSpacing: "5px", fontSize: "33px" }}
      >
        Welcome to Cluber!
      </motion.h1>
      <form onSubmit={submitHandler}>
        <Grid container spacing={3} direction="column">
          <Grid item>
            <TextField
              id="outlined-email"
              placeholder="Enter your email"
              label="Email"
              variant="standard"
              required
              fullWidth
            />
          </Grid>
          <Grid item>
            <TextField
              id="outlined-password"
              label="Password"
              variant="standard"
              placeholder="Enter your password"
              required
              fullWidth
            />
          </Grid>
          <Grid item>
            <Button
              onClick={submitHandler}
              variant="contained"
              size="large"
              fullWidth
              startIcon={<BiLogIn />}
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
        <p style={{ fontWeight: "600", marginRight: "10px" }}>
          Don't have an account?
        </p>
        <Button onClick={onLinkClick} className={classes.btnBottom}>
          Sign In
        </Button>
      </div>
    </FormCard>
  );
};

export default LoginForm;
