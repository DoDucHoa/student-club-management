import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { Formik, Form, Field } from "formik";
import { useSelector } from "react-redux";

// materials
import {
  Button,
  Container,
  Grid,
  Paper,
  TextField,
  Typography,
} from "@mui/material";
import Page from "../../../UI/Page";
import { styled } from "@mui/material/styles";
import ArrowBackIosIcon from "@mui/icons-material/ArrowBackIos";
import { Box } from "@mui/system";
import { GetMemberId } from "./Components/action";

const ImageContaier = styled("div")(({ theme }) => ({
  width: "144px",
  height: "144px",
  borderRadius: "8px",
  padding: "8px",
  border: "1px",
  borderStyle: "solid",
}));

const CreateActivity = () => {
  const navigate = useNavigate();
  const userId = useSelector((state) => state.auth.userId);
  const token = useSelector((state) => state.auth.token);

  const [imageUrl, setImageUrl] = useState("");
  const [uploadImage, setUploadImage] = useState(null);
  const [memberId, setMemberId] = useState(null);

  useEffect(() => {
    GetMemberId(token, userId, "BAS").then((data) => setMemberId(data));
  }, [token, userId]);

  function imageHandler(event) {
    if (event.target.files[0]) {
      setUploadImage(event.target.files[0]);

      var reader = new FileReader();
      reader.readAsDataURL(event.target.files[0]);
      reader.onloadend = (e) => {
        setImageUrl(reader.result);
      };
    }
  }

  const goBackHandler = () => {
    navigate(-1);
  };

  function submitHandler(data) {
    fetch("https://club-management-service.azurewebsites.net/api/v1/events", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Authorization: "Bearer " + token,
      },
      body: JSON.stringify({ ...data, creatorId: memberId, status: 1 }),
    });
  }

  const initialValues = {
    title: "",
    content: "",
    regisDate: "",
    endRegisDate: "",
    beginDate: "",
    dueDate: "",
    bonusPoint: 0,
    limitJoin: 0,
    image: "",
    location: "",
  };

  return (
    <Page title="Create Activity">
      <Button startIcon={<ArrowBackIosIcon />} onClick={goBackHandler}>
        Back
      </Button>
      <Container>
        <Typography variant="h4" sx={{ mb: 4 }} gutterBottom>
          New Activity
        </Typography>
        <Formik
          initialValues={initialValues}
          onSubmit={(data, { resetForm }) => {
            submitHandler(data);
            resetForm();
          }}
        >
          {({ values }) => (
            <Form>
              <Paper elevation={5} sx={{ p: 5, width: { lg: "65%" } }}>
                <Grid container spacing={3}>
                  <Grid item xs={12}>
                    <Field
                      name="title"
                      label="Title"
                      required
                      fullWidth
                      as={TextField}
                    />
                  </Grid>
                  <Grid item xs={12}>
                    <Field
                      name="content"
                      label="Content"
                      fullWidth
                      required
                      multiline
                      rows={7}
                      as={TextField}
                    />
                  </Grid>
                  <Grid item xs={12} md={6}>
                    <Field
                      name="regisDate"
                      required
                      as={TextField}
                      label="Register date"
                      fullWidth
                      type="date"
                      InputLabelProps={{
                        shrink: true,
                      }}
                    />
                  </Grid>
                  <Grid item xs={12} md={6}>
                    <Field
                      name="endRegisDate"
                      required
                      as={TextField}
                      label="End register date"
                      fullWidth
                      type="date"
                      InputLabelProps={{
                        shrink: true,
                      }}
                    />
                  </Grid>
                  <Grid item xs={12} md={6}>
                    <Field
                      name="beginDate"
                      required
                      as={TextField}
                      label="Begin date"
                      fullWidth
                      type="date"
                      InputLabelProps={{
                        shrink: true,
                      }}
                    />
                  </Grid>
                  <Grid item xs={12} md={6}>
                    <Field
                      name="dueDate"
                      required
                      as={TextField}
                      label="Due date"
                      fullWidth
                      type="date"
                      InputLabelProps={{
                        shrink: true,
                      }}
                    />
                  </Grid>
                  <Grid item xs={12} md={6}>
                    <Field
                      name="bonusPoint"
                      as={TextField}
                      label="Bonus point"
                      type="number"
                      fullWidth
                    />
                  </Grid>
                  <Grid item xs={12} md={6}>
                    <Field
                      name="limitJoin"
                      as={TextField}
                      label="Limit join"
                      type="number"
                      fullWidth
                    />
                  </Grid>
                  <Grid item xs={12}>
                    <Field
                      name="location"
                      as={TextField}
                      label="Location"
                      fullWidth
                    />
                  </Grid>
                  <Grid item xs={12} md={6}>
                    <Button
                      component="label"
                      color="secondary"
                      variant="contained"
                    >
                      Upload Image
                      <Field
                        name="image"
                        accept=".jpg, .jpeg, .png"
                        type="file"
                        hidden
                        onChange={imageHandler}
                      />
                    </Button>
                  </Grid>
                  {imageUrl && (
                    <Grid item xs={12} md={6}>
                      <ImageContaier>
                        <img src={imageUrl} alt="Event" />
                      </ImageContaier>
                    </Grid>
                  )}
                </Grid>
                <Grid item xs={12}>
                  <Box
                    sx={{
                      display: "flex",
                      mt: 5,
                      alignContent: "center",
                      alignItems: "center",
                      justifyContent: "space-between",
                    }}
                  >
                    <Button
                      sx={{ mx: 1 }}
                      fullWidth
                      variant="contained"
                      color="error"
                    >
                      Cancel
                    </Button>
                    <Button
                      sx={{ mx: 1 }}
                      fullWidth
                      variant="contained"
                      type="submit"
                    >
                      Create
                    </Button>
                  </Box>
                </Grid>
              </Paper>
            </Form>
          )}
        </Formik>
      </Container>
    </Page>
  );
};

export default CreateActivity;
