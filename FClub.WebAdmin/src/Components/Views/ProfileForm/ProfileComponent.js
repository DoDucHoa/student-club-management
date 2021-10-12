import React, { useState, useEffect } from "react";
import { useSelector } from "react-redux";
import { useFormik } from "formik";

// material
import {
  Container,
  Stack,
  Typography,
  Paper,
  Grid,
  TextField,
  Box,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
  Button,
} from "@mui/material";
import { styled } from "@mui/material/styles";
import { makeStyles } from "@mui/styles";

// component
import Page from "../../UI/Page";
import ACCOUNT from "../../../_mock_/account";

const FormRoot = styled("div")(({ theme }) => ({
  display: "flex",
  flexDirection: "column",
}));

const FormRow = styled("div")(({ theme }) => ({
  display: "flex",
  flexDirection: "column",

  [theme.breakpoints.up("lg")]: {
    flexDirection: "row",
  },
}));

const ImageContaier = styled("div")(({ theme }) => ({
  width: "144px",
  height: "144px",
  margin: "auto",
  borderRadius: "50%",
  padding: "8px",
  border: "1px",
}));

const ImageHolder = styled("div")(({ theme }) => ({
  width: "100%",
  height: "100%",
  outline: "none",
  display: "flex",
  overflow: "hidden",
  borderRadius: "50%",
  position: "relative",
  alignItems: "center",
  justifyContent: "center",
}));

const useStyles = makeStyles((theme) => ({
  inputControl: {
    margin: "10px 0",

    [theme.breakpoints.up("lg")]: {
      margin: "10px",
    },
  },
}));

const ProfileComponent = () => {
  const classes = useStyles();
  const [profile, setProfile] = useState({});

  const userId = useSelector((state) => state.auth.userId);
  const token = useSelector((state) => state.auth.token);

  useEffect(() => {
    fetch(
      "https://club-management-service.azurewebsites.net/api/v1/users?id=" +
        userId,
      {
        headers: {
          Authorization: "Bearer " + token,
        },
      }
    )
      .then((res) => {
        if (res.ok) {
          return res.json();
        } else {
          throw new Error(res.statusText);
        }
      })
      .then((resData) => {
        setProfile(resData.data[0]);
      })
      .catch((err) => {
        console.log(err);
      });
  }, [userId, token]);

  const formik = useFormik({
    enableReinitialize: true,

    initialValues: {
      name: "",
      email: "",
      phone: "",
      birth: "",
      gender: 0,
      school: "",
      about: "",
    },

    onSubmit: (values) => {},
  });

  return (
    <Page title="account">
      {/* Container: centers content horizontally */}
      <Container>
        <Stack mb={5}>
          <Typography variant="h4" gutterBottom>
            Account
          </Typography>
        </Stack>

        <form onSubmit={formik.handleSubmit}>
          <Box sx={{ display: "flex" }}>
            <Grid container spacing={4}>
              <Grid item xs={12} md={4}>
                <Paper elevation={6} sx={{ py: 10 }}>
                  <ImageContaier>
                    <ImageHolder>
                      <input
                        accept=".jpg, .png"
                        type="file"
                        hidden
                        autoComplete="off"
                        tabIndex="-1"
                      />
                      <img src={ACCOUNT.photoURL} alt="Ava" />
                    </ImageHolder>
                  </ImageContaier>
                  <Box
                    sx={{
                      display: "flex",
                      flexDirection: "column",
                      alignItems: "center",
                      justifyContent: "center",
                    }}
                  >
                    <Button component="label">
                      Choose Image
                      <input accept=".jpg, .jpeg, .png" type="file" hidden />
                    </Button>
                    <Typography variant="caption">
                      Allowed *.jpeg, *.jpg, *.png
                    </Typography>
                    <Typography variant="caption">max size of 3 MB</Typography>
                  </Box>
                </Paper>
              </Grid>

              <Grid item xs={12} md={8}>
                <Paper elevation={6} sx={{ p: 3 }}>
                  <FormRoot>
                    <FormRow>
                      <TextField
                        id="name"
                        className={classes.inputControl}
                        fullWidth
                        label="Name"
                        variant="outlined"
                        value={formik.values.name}
                        onChange={formik.handleChange}
                      />
                      <TextField
                        id="email"
                        className={classes.inputControl}
                        fullWidth
                        label="Email Address"
                        variant="outlined"
                        type="email"
                        value={formik.values.email}
                        onChange={formik.handleChange}
                      />
                    </FormRow>
                    <FormRow>
                      <TextField
                        id="phone"
                        className={classes.inputControl}
                        fullWidth
                        label="Phone"
                        variant="outlined"
                        type="tel"
                        value={formik.values.phone}
                        onChange={formik.handleChange}
                      />
                      <TextField
                        id="birth"
                        className={classes.inputControl}
                        fullWidth
                        label="Birthday"
                        variant="outlined"
                        type="date"
                        value={formik.values.birth}
                        onChange={formik.handleChange}
                        InputLabelProps={{
                          shrink: true,
                        }}
                      />
                    </FormRow>
                    <FormRow>
                      <FormControl fullWidth className={classes.inputControl}>
                        <InputLabel id="gender-label">Gender</InputLabel>
                        <Select
                          labelId="gender-label"
                          id="gender"
                          label="Gender"
                          value={formik.values.gender}
                          onChange={formik.handleChange}
                        >
                          <MenuItem value={0}>Male</MenuItem>
                          <MenuItem value={1}>Female</MenuItem>
                          <MenuItem value={2}>Other</MenuItem>
                        </Select>
                      </FormControl>

                      <FormControl fullWidth className={classes.inputControl}>
                        <InputLabel id="university-label">School</InputLabel>
                        <Select
                          labelId="university-label"
                          label="Gender"
                          value={formik.values.school}
                          onChange={formik.handleChange}
                        >
                          <MenuItem value={0}>Male</MenuItem>
                          <MenuItem value={1}>Female</MenuItem>
                          <MenuItem value={2}>Other</MenuItem>
                        </Select>
                      </FormControl>
                    </FormRow>
                    <FormRow>
                      <TextField
                        id="about"
                        className={classes.inputControl}
                        label="About"
                        fullWidth
                        multiline
                        rows={5}
                        value={formik.values.about}
                        onChange={formik.handleChange}
                      />
                    </FormRow>
                    <Box
                      sx={{
                        mt: 2,
                        mr: { xs: 0, lg: "10px" },
                        display: "flex",
                        justifyContent: "flex-end",
                      }}
                    >
                      <Button variant="contained">Save Changes</Button>
                    </Box>
                  </FormRoot>
                </Paper>
              </Grid>
            </Grid>
          </Box>
        </form>
      </Container>
    </Page>
  );
};

export default ProfileComponent;