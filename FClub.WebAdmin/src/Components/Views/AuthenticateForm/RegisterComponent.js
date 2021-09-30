import { Grid, TextField } from "@mui/material";
import React, { useState, useEffect } from "react";
import FormCard from "../../UI/FormCard";

const RegisterComponent = (props) => {
  const [password, setPassword] = useState("");
  const [repassword, setRepassword] = useState("");
  const [repasswordIsValid, setRepasswordIsValid] = useState(null);

  useEffect(() => {
    setRepasswordIsValid(password === repassword);
  }, [password, repassword]);

  const passwordChangeHandler = (event) => {
    setPassword(event.target.value);
  };

  const repasswordChangeHandler = (event) => {
    setRepassword(event.target.value);
  };

  const submitHandler = () => {
    console.log(1);
  };

  return (
    <FormCard>
      <h1>Regiser</h1>
      <Grid container spacing={4}>
        <Grid item>
          <TextField
            id="standard-email"
            placeholder="Enter your email"
            label="Email"
            variant="standard"
          />
        </Grid>
        <Grid item>
          <TextField
            id="standard-name"
            placeholder="Enter your name"
            label="Name"
            variant="standard"
          />
        </Grid>
        <Grid item>
          <TextField
            id="standard-password"
            placeholder="Enter your password"
            label="Password"
            variant="standard"
          />
        </Grid>
      </Grid>
    </FormCard>
  );
};

export default RegisterComponent;
