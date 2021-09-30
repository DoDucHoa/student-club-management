import { Grid, TextField } from "@mui/material";
import React from "react";
import FormCard from "../../UI/FormCard";

const RegisterComponent = (props) => {
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
