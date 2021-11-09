import React, { useEffect, useRef, useState } from "react";
import { useNavigate } from "react-router";
import { Formik, Form, Field } from "formik";

import {
  Alert,
  Button,
  FormControl,
  Grid,
  InputLabel,
  MenuItem,
  Paper,
  Select,
  Slide,
  Snackbar,
  TextField,
} from "@mui/material";
import { styled } from "@mui/material/styles";
import { Box } from "@mui/system";
import { createClubHandler } from "./Components/action";
import { useSelector } from "react-redux";

const initValue = {
  id: "",
  name: "",
};

const ImageContaier = styled("div")(({ theme }) => ({
  borderRadius: "10px",
  padding: "8px",
  border: "1px",
  borderStyle: "dashed",
}));

const CreateClubComponent = () => {
  const navigate = useNavigate();
  const token = useSelector((state) => state.auth.token);

  const schoolInputRef = useRef();

  const [isSnackbarOpen, setIsSnackbarOpen] = useState(false);

  const [school, setSchool] = useState("");
  const [schoolData, setSchoolData] = useState([]);

  const [imageUrl, setImageUrl] = useState("");
  const [uploadImage, setUploadImage] = useState(null);

  useEffect(() => {
    fetch(
      "https://club-management-service.azurewebsites.net/api/v1/universities?PageSize=100"
    )
      .then((res) => {
        if (res.ok) {
          return res.json();
        } else {
          throw new Error(res.statusText);
        }
      })
      .then((resData) => {
        setSchoolData(resData.data);
      })
      .catch((err) => {
        console.log(err);
      });
  }, []);

  const schoolHandler = (event) => {
    setSchool(event.target.value);
  };

  function uploadImageHandler(event) {
    if (event.target.files[0]) {
      setUploadImage(event.target.files[0]);

      // show the upload photo to the screen
      var reader = new FileReader();
      reader.readAsDataURL(event.target.files[0]);
      reader.onloadend = (e) => {
        setImageUrl(reader.result);
      };
    }
  }

  function submitHandler(data) {
    createClubHandler(uploadImage, token, data);
    setIsSnackbarOpen(true);
  }

  const handleCloseSnackbar = (event, reason) => {
    if (reason === "clickaway") {
      return;
    }

    setIsSnackbarOpen(false);
  };

  function TransitionSnackbarLeft(props) {
    return <Slide {...props} direction="left" />;
  }

  return (
    <>
      <Formik
        initialValues={initValue}
        onSubmit={(data, { resetForm }) => {
          submitHandler({ universityId: school, ...data });
          resetForm();
          setImageUrl("");
          setUploadImage(null);
          setSchool("");
        }}
      >
        {() => (
          <Form>
            <Paper elevation={8} sx={{ p: 5, width: "70%" }}>
              <Grid container spacing={4}>
                <Grid item xs={12}>
                  <Field
                    name="id"
                    label="Club ID"
                    fullWidth
                    required
                    inputProps={{
                      maxLength: 32,
                      style: { textTransform: "uppercase" },
                    }}
                    as={TextField}
                  />
                </Grid>
                <Grid item xs={12}>
                  <Field
                    as={TextField}
                    name="name"
                    label="Club Name"
                    fullWidth
                    required
                    placeholder="Enter club name"
                  />
                </Grid>
                <Grid item xs={12}>
                  <FormControl fullWidth required>
                    <InputLabel id="university-label">School</InputLabel>
                    <Select
                      labelId="university-label"
                      label="School"
                      value={school}
                      onChange={schoolHandler}
                      inputRef={schoolInputRef}
                    >
                      {schoolData.length !== 0 ? (
                        schoolData.map((item) => {
                          return (
                            <MenuItem key={item.id} value={item.id}>
                              {item.name}
                            </MenuItem>
                          );
                        })
                      ) : (
                        <MenuItem key="" value="">
                          Loading...
                        </MenuItem>
                      )}
                    </Select>
                  </FormControl>
                </Grid>
                <Grid item xs={12} md={6}>
                  <Button
                    component="label"
                    color="secondary"
                    variant="contained"
                  >
                    Upload Logo
                    <input
                      name="image"
                      accept=".jpg, .jpeg, .png"
                      type="file"
                      hidden
                      onChange={uploadImageHandler}
                    />
                  </Button>
                </Grid>
                {imageUrl && (
                  <Grid item xs={12} md={6}>
                    <ImageContaier>
                      <img
                        style={{ maxWidth: 200 }}
                        src={imageUrl}
                        alt="Event"
                      />
                    </ImageContaier>
                  </Grid>
                )}
              </Grid>
              <Box
                sx={{
                  textAlign: "center",
                  mt: 4,
                  display: "flex",
                  justifyContent: "space-between",
                }}
              >
                <Button
                  variant="contained"
                  color="error"
                  fullWidth
                  onClick={() => {
                    navigate(-1);
                  }}
                >
                  Cancel
                </Button>
                <Button variant="contained" type="submit" fullWidth>
                  Create
                </Button>
              </Box>
            </Paper>
          </Form>
        )}
      </Formik>
      <Snackbar
        open={isSnackbarOpen}
        autoHideDuration={5000}
        onClose={handleCloseSnackbar}
        anchorOrigin={{ horizontal: "center", vertical: "bottom" }}
        TransitionComponent={TransitionSnackbarLeft}
      >
        <Alert
          onClose={handleCloseSnackbar}
          severity="success"
          sx={{ width: "100%", bgcolor: "#2E7D32", color: "white" }}
        >
          Create success!
        </Alert>
      </Snackbar>
    </>
  );
};

export default CreateClubComponent;
