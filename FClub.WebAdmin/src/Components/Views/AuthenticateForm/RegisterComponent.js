import React, { useRef } from "react";
import { Link } from "react-router-dom";

import FormCard from "../../UI/FormCard";

import { motion } from "framer-motion";

import { Button, Grid, TextField } from "@mui/material";
import { makeStyles } from "@mui/styles";
import CheckCircleOutlineIcon from "@mui/icons-material/CheckCircleOutline";

const useStyles = makeStyles((theme) => ({
  link: {
    marginTop: "20px",
  },
}));

const RegisterComponent = () => {
  const classes = useStyles();

  const emailInputRef = useRef();
  const passwordInputRef = useRef();

  const submitHandler = (event) => {
    event.preventDefault();

    const enteredEmail = emailInputRef.current.value;
    const enteredPassword = passwordInputRef.current.value;

    // add valid later
    fetch(
      "https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=AIzaSyBqDw1-2F_ycVi-Y6VTztrfekcl3WBbs9I",
      {
        method: "POST",
        body: JSON.stringify({
          email: enteredEmail,
          password: enteredPassword,
          returnSecureToken: true,
        }),
        headers: {
          "Content-Type": "application/json",
        },
      }
    ).then((response) => {
      if (response.ok) {
        console.log(response);
      } else {
        response.json().then((data) => {
          console.log(data);
        });
      }
    });
  };

  return (
    <FormCard>
      <motion.h1
        initial={{ fontSize: "0px" }}
        animate={{ letterSpacing: "5px", fontSize: "33px" }}
      >
        Register
      </motion.h1>
      <form onSubmit={submitHandler}>
        <Grid container spacing={4}>
          <Grid item>
            <TextField
              inputRef={emailInputRef}
              id="standard-email"
              placeholder="Enter your email"
              label="Email"
              variant="standard"
              required
            />
          </Grid>
          <Grid item>
            <TextField
              inputRef={passwordInputRef}
              id="standard-name"
              placeholder="Enter your name"
              label="Name"
              variant="standard"
              required
            />
          </Grid>
          <Grid item>
            <TextField
              id="standard-password"
              placeholder="Enter your password"
              label="Password"
              variant="standard"
              required
            />
          </Grid>
          <Grid item>
            <TextField
              id="standard-repassword"
              placeholder="Confirm your password"
              label="Confirm Password"
              variant="standard"
              required
            />
          </Grid>
          <Grid item md={6} sm={6} xs={12}>
            <Button
              variant="contained"
              size="large"
              fullWidth
              type="submit"
              startIcon={<CheckCircleOutlineIcon />}
            >
              SIGN UP
            </Button>
          </Grid>
        </Grid>
      </form>
      <div className={classes.link}>
        <Link to="/login" style={{ textDecoration: "none" }}>
          <Button>Back to Sign In</Button>
        </Link>
      </div>
    </FormCard>
  );
};

export default RegisterComponent;
