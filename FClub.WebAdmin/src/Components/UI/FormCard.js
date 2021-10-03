import { Paper } from "@mui/material";
import { makeStyles } from "@mui/styles";
import React from "react";

const useStyles = makeStyles((theme) => ({
  root: {
    margin: "10rem auto",
    width: "40rem",
    height: "30rem",
    padding: "3rem 5rem 5rem 5rem",

    [theme.breakpoints.down("md")]: {
      margin: "6rem auto",
      width: "35rem",
      height: "31rem",
      padding: "4rem",
    },
    [theme.breakpoints.down("sm")]: {
      width: "20rem",
      height: "35rem",
      padding: "2rem 3rem",
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
