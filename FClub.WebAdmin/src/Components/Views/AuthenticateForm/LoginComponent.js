// react
import React, { useRef, useEffect } from "react";
import { useHistory } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { Link } from "react-router-dom";

// component
import FormCard from "../../UI/FormCard";
import PasswordField from "../../UI/PasswordField";

// framer
import { motion } from "framer-motion";

// material ui
import { makeStyles } from "@mui/styles";
import {
  TextField,
  Grid,
  Button,
  Divider,
  Box,
  FormControlLabel,
  Checkbox,
} from "@mui/material";

// icon
import { BiLogIn } from "react-icons/bi";
import TwitterIcon from "@mui/icons-material/Twitter";
import { FcGoogle } from "react-icons/fc";
import FacebookIcon from "@mui/icons-material/Facebook";

// context
import {
  signIn,
  signInWithGoogle,
} from "../../../Context/Actions/authen-action";

// ====================================================

const useStyles = makeStyles((theme) => ({
  bottom: {
    textAlign: "center",
    display: "flex",
  },
  btnBottom: {
    [theme.breakpoints.down("sm")]: {
      padding: 0,
      margin: 0,
    },
  },
  signDivider: {
    flexGrow: 1,
  },
}));

const LoginForm = () => {
  const classes = useStyles();
  const dispatch = useDispatch();
  const history = useHistory();

  const isLoggedIn = useSelector((state) => state.auth.isLoggedIn);
  const isLoading = useSelector((state) => state.auth.isLoading);
  const isEmailError = useSelector((state) => state.error.isEmailError);
  const emailErrorMessage = useSelector(
    (state) => state.error.emailErrorMessage
  );
  const isPasswordError = useSelector((state) => state.error.isPasswordError);
  const passwordErrorMessage = useSelector(
    (state) => state.error.passwordErrorMessage
  );

  const inputEmailRef = useRef();
  const inputPasswordRef = useRef();

  const submitHandler = (event) => {
    event.preventDefault();
    const enteredEmail = inputEmailRef.current.value;
    const enteredPassword = inputPasswordRef.current.value;

    dispatch(signIn(enteredEmail, enteredPassword));
  };

  useEffect(() => {
    if (isLoggedIn) {
      history.push("/");
    }
  }, [isLoggedIn, history]);

  const signInWithGoogleHandler = () => {
    dispatch(signInWithGoogle());
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
        <Grid container spacing={2} direction="column">
          <Grid item>
            <TextField
              inputRef={inputEmailRef}
              id="outlined-email"
              placeholder="Enter your email"
              label="Email"
              variant="standard"
              required
              fullWidth
              error={isEmailError}
              helperText={emailErrorMessage}
            />
          </Grid>
          <Grid item>
            <PasswordField
              id="password"
              label="Password"
              placeholder="Enter your password"
              inputRef={inputPasswordRef}
              isError={isPasswordError}
              helperText={passwordErrorMessage}
            />
          </Grid>
          <Grid item>
            <FormControlLabel
              sx={{ marginLeft: 2 }}
              control={<Checkbox sx={{ margin: 0, padding: "0 10px 0 0" }} />}
              label="Remember me"
            />
          </Grid>
          <Grid item>
            <Button
              sx={{ margin: 0 }}
              variant="contained"
              type="submit"
              size="large"
              fullWidth
              startIcon={<BiLogIn />}
            >
              {!isLoading ? "SIGN IN" : "Loading ..."}
            </Button>
          </Grid>
        </Grid>
      </form>

      <div style={{ marginTop: "1rem" }}>
        <Grid container spacing={{ sm: 16 }}>
          <Grid item>
            <Button className={classes.btnBottom}>
              <Link
                to="/register"
                style={{ textDecoration: "none", color: "#0E86D4" }}
              >
                Don't have an account?
              </Link>
            </Button>
          </Grid>
          <Grid item>
            <Button className={classes.btnBottom}>
              <Link
                to="/register"
                underline="always"
                style={{ textDecoration: "none", color: "#0E86D4" }}
              >
                Forgot password
              </Link>
            </Button>
          </Grid>
        </Grid>
      </div>

      <Box
        sx={{
          alignItems: "center",
          display: "flex",
          margin: "7px",
        }}
      >
        <Divider className={classes.signDivider} orientation="horizontal" />
        <Button
          sx={{ margin: "0px 20px", padding: 0 }}
          variant="outlined"
          disableRipple
          disabled
        >
          OR
        </Button>
        <Divider className={classes.signDivider} orientation="horizontal" />
      </Box>

      <Grid
        sx={{ marginTop: "1px" }}
        container
        spacing={3}
        justifyContent="space-evenly"
        alignItems="center"
      >
        <Grid item xs={12} sm={4}>
          <motion.div whileHover={{ scale: 1.2 }} whileTap={{ scale: 0.9 }}>
            <Button
              startIcon={<FcGoogle />}
              variant="contained"
              color="inherit"
              onClick={signInWithGoogleHandler}
              fullWidth
            >
              Google
            </Button>
          </motion.div>
        </Grid>
        <Grid item xs={12} sm={4}>
          <motion.div whileHover={{ scale: 1.2 }} whileTap={{ scale: 0.9 }}>
            <Button
              className={classes.btnFacebook}
              sx={{ backgroundColor: "#3b5998" }}
              startIcon={<FacebookIcon sx={{ color: "white" }} />}
              variant="contained"
              fullWidth
            >
              Facebook
            </Button>
          </motion.div>
        </Grid>
        <Grid item xs={12} sm={4}>
          <motion.div whileHover={{ scale: 1.2 }} whileTap={{ scale: 0.9 }}>
            <Button
              sx={{ backgroundColor: "#00acee" }}
              startIcon={<TwitterIcon sx={{ color: "white" }} />}
              variant="contained"
              fullWidth
            >
              Twitter
            </Button>
          </motion.div>
        </Grid>
      </Grid>
    </FormCard>
  );
};

export default LoginForm;
