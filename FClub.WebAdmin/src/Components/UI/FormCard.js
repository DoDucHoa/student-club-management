import { Paper } from "@mui/material";
import { makeStyles } from "@mui/styles";
import React from "react";

const useStyles = makeStyles((theme) => ({
  root: {
    margin: "10rem auto",
    width: "30rem",
    height: "20rem",
    padding: "5rem",
    [theme.breakpoints.down("md")]: {
      width: "20rem",
      height: "23rem",
      padding: "4rem",
    },
    [theme.breakpoints.down("sm")]: {
      width: "15rem",
      height: "28rem",
      padding: "3rem 3rem",
      margin: "5rem auto",
    },
  },
}));

const FormCard = (props) => {
  const classes = useStyles();

  return (
    <Paper elevation={6} className={classes.root}>
      {props.children}
    </Paper>
  );
};

export default FormCard;
