import React, { useRef, useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";

// redux
import { useDispatch, useSelector } from "react-redux";
import { signUp } from "../../../Context/Actions/authen-action";

// framer
import { motion } from "framer-motion";

// component
import FormCard from "../../UI/FormCard";
import PasswordField from "../../UI/PasswordField";

// icons
import ArrowBackIosIcon from "@mui/icons-material/ArrowBackIos";

// material ui
import { Button, Grid, TextField } from "@mui/material";
import { makeStyles } from "@mui/styles";
import CheckCircleOutlineIcon from "@mui/icons-material/CheckCircleOutline";

const useStyles = makeStyles((theme) => ({
  link: {
    marginTop: "20px",
  },
  textContainer: {
    width: "22ch",
  },
}));

const RegisterComponent = () => {
  const classes = useStyles();
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const isLoggedIn = useSelector((state) => state.auth.isLoggedIn);
  const isLoading = useSelector((state) => state.auth.isLoading);

  const emailInputRef = useRef();
  const passwordInputRef = useRef();

  const submitHandler = (event) => {
    event.preventDefault();

    const enteredEmail = emailInputRef.current.value;
    const enteredPassword = passwordInputRef.current.value;

    dispatch(signUp(enteredEmail, enteredPassword));
  };

  useEffect(() => {
    if (isLoggedIn) {
      navigate("/");
    }
  }, [isLoggedIn, navigate]);

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
            <div className={classes.textContainer}>
              <TextField
                inputRef={emailInputRef}
                id="standard-email"
                placeholder="Enter your email"
                label="Email"
                variant="standard"
                required
                fullWidth
              />
            </div>
          </Grid>
          <Grid item>
            <div className={classes.textContainer}>
              <TextField
                id="standard-name"
                placeholder="Enter your name"
                label="Name"
                variant="standard"
                required
                fullWidth
              />
            </div>
          </Grid>
          <Grid item>
            <div className={classes.textContainer}>
              <PasswordField
                id="password"
                label="Password"
                placeholder="Enter your password"
                inputRef={passwordInputRef}
              />
            </div>
          </Grid>
          <Grid item>
            <div className={classes.textContainer}>
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
              {isLoading ? "Loading..." : "SIGN UP"}
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
