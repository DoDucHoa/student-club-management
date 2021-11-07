import React, { useEffect, useRef, useState } from "react";
import { useNavigate } from "react-router";

import {
  Button,
  FormControl,
  Grid,
  InputLabel,
  MenuItem,
  Paper,
  Select,
  TextField,
} from "@mui/material";
import { styled } from "@mui/material/styles";
import { Box } from "@mui/system";

const ImageContaier = styled("div")(({ theme }) => ({
  borderRadius: "10px",
  padding: "8px",
  border: "1px",
  borderStyle: "dashed",
}));

const CreateClubComponent = () => {
  const navigate = useNavigate();
  const [schoolData, setSchoolData] = useState([]);
  const [school, setSchool] = useState("");

  const schoolInputRef = useRef();

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

  return (
    <>
      <Paper elevation={8} sx={{ p: 5, width: "70%" }}>
        <Grid container spacing={4}>
          <Grid item xs={12}>
            <TextField
              label="Club ID"
              fullWidth
              required
              inputProps={{
                maxLength: 32,
                style: { textTransform: "uppercase" },
              }}
            />
          </Grid>
          <Grid item xs={12}>
            <TextField
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
            <Button component="label" color="secondary" variant="contained">
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
                <img style={{ maxWidth: 200 }} src={imageUrl} alt="Event" />
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
          <Button variant="contained" fullWidth>
            Create
          </Button>
        </Box>
      </Paper>
    </>
  );
};

export default CreateClubComponent;
