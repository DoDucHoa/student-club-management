import React, { useState, useRef, useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";

// redux
import { useDispatch, useSelector } from "react-redux";
import { signUp } from "../../../Context/Actions/authen-action";

// framer
import { motion } from "framer-motion";

// component
import FormCard from "../../UI/FormCard";

// material ui
import {
  Button,
  FormControl,
  Grid,
  InputLabel,
  MenuItem,
  Select,
  TextField,
  Typography,
} from "@mui/material";
import { makeStyles } from "@mui/styles";
import CheckCircleOutlineIcon from "@mui/icons-material/CheckCircleOutline";
import { LoadingButton } from "@mui/lab";

const useStyles = makeStyles((theme) => ({
  link: {
    marginTop: "20px",
  },
}));

const RegisterComponent = () => {
  const classes = useStyles();
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const isLoggedIn = useSelector((state) => state.auth.isLoggedIn);
  const isLoading = useSelector((state) => state.auth.isLoading);

  const phoneInputRef = useRef();

  const [gender, setGender] = useState(1);
  const [schoolData, setSchoolData] = useState([]);
  const [school, setSchool] = useState("FPT");

  const schoolHandler = (event) => {
    setSchool(event.target.value);
  };

  const genderHandler = (event) => {
    setGender(event.target.value);
  };

  // get school
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
  //

  const submitHandler = (event) => {
    event.preventDefault();
  };

  useEffect(() => {
    if (isLoggedIn) {
      navigate("/");
    }
  }, [isLoggedIn, navigate]);

  return (
    <FormCard>
      <motion.div
        initial={{ fontSize: "0px" }}
        animate={{ letterSpacing: "5px", fontSize: "33px" }}
      >
        <Typography mb={4} align="left" variant="h3">
          One more step
        </Typography>
      </motion.div>

      <form onSubmit={submitHandler}>
        <Grid container spacing={4}>
          <Grid item xs={12}>
            <div className={classes.textContainer}>
              <FormControl fullWidth required className={classes.inputControl}>
                <InputLabel id="university-label">School</InputLabel>
                <Select
                  labelId="university-label"
                  label="School"
                  value={school}
                  onChange={schoolHandler}
                >
                  {schoolData.map((item) => {
                    return (
                      <MenuItem key={item.id} value={item.id}>
                        {item.name}
                      </MenuItem>
                    );
                  })}
                </Select>
              </FormControl>
            </div>
          </Grid>
          <Grid item xs={12}>
            <div className={classes.textContainer}>
              <TextField
                inputRef={phoneInputRef}
                id="standard-phone"
                placeholder="Enter your phone"
                label="Phone"
                fullWidth
              />
            </div>
          </Grid>
          <Grid item xs={12}>
            <div className={classes.textContainer}>
              <TextField
                id="standard-birth"
                label="Birthday"
                type="date"
                fullWidth
                InputLabelProps={{
                  shrink: true,
                }}
              />
            </div>
          </Grid>
          <Grid item xs={12}>
            <div className={classes.textContainer}>
              <FormControl fullWidth className={classes.inputControl}>
                <InputLabel id="gender-label">Gender</InputLabel>
                <Select
                  labelId="university-label"
                  label="School"
                  value={gender}
                  onChange={genderHandler}
                >
                  <MenuItem key={1} value={1}>
                    Male
                  </MenuItem>
                  <MenuItem key={2} value={2}>
                    Female
                  </MenuItem>
                  <MenuItem key={3} value={3}>
                    Other
                  </MenuItem>
                </Select>
              </FormControl>
            </div>
          </Grid>

          <Grid item md={6} sm={6} xs={12}>
            <LoadingButton
              sx={{
                margin: 0,
                "&:disabled": {
                  cursor: "not-allowed",
                  pointerEvents: "all !important",
                },
              }}
              startIcon={<CheckCircleOutlineIcon />}
              type="submit"
              size="large"
              loadingPosition="start"
              variant="contained"
              fullWidth
              disabled={isLoading}
              loading={isLoading}
            >
              {isLoading ? "Loading..." : "COMPLETE"}
            </LoadingButton>
          </Grid>
        </Grid>
      </form>
    </FormCard>
  );
};

export default RegisterComponent;
