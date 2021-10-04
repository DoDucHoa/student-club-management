import React, { useRef } from "react";
import { Link } from "react-router-dom";

// redux
import { useDispatch } from "react-redux";
import { signUp } from "../../../Context/authen-action";

// framer
import { motion } from "framer-motion";

// material ui
import { Button, Grid, TextField } from "@mui/material";
import { makeStyles } from "@mui/styles";
import CheckCircleOutlineIcon from "@mui/icons-material/CheckCircleOutline";
import FormCard from "../../UI/FormCard";
import PasswordField from "../../UI/PasswordField";
import ArrowBackIosIcon from "@mui/icons-material/ArrowBackIos";

const useStyles = makeStyles((theme) => ({
  link: {
    marginTop: "20px",
  },
}));

const RegisterComponent = () => {
  const classes = useStyles();
  const dispatch = useDispatch();

  const emailInputRef = useRef();
  const passwordInputRef = useRef();

  const submitHandler = (event) => {
    event.preventDefault();

    const enteredEmail = emailInputRef.current.value;
    const enteredPassword = passwordInputRef.current.value;

    dispatch(signUp(enteredEmail, enteredPassword));
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
              id="standard-name"
              placeholder="Enter your name"
              label="Name"
              variant="standard"
              required
            />
          </Grid>
          <Grid item>
            <div style={{ width: "22ch" }}>
              <PasswordField
                id="password"
                label="Password"
                placeholder="Enter your password"
                inputRef={passwordInputRef}
              />
            </div>
          </Grid>
          <Grid item>
            <div style={{ width: "22ch" }}>
              <PasswordField
                id="re-password"
                label="Confirm Password"
                placeholder="Re-enter password"
                inputRef={passwordInputRef}
              />
            </div>
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
          <Button startIcon={<ArrowBackIosIcon />}>Back to Sign In</Button>
        </Link>
      </div>
    </FormCard>
  );
};

export default RegisterComponent;
