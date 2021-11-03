import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";

// materials
import { Button, Card, Container, Typography } from "@mui/material";
import ArrowBackIosIcon from "@mui/icons-material/ArrowBackIos";

// components
import Page from "../../../UI/Page";
import BlogPostHero from "../../../UI/BlogPostHero";
import Content from "./Components/Content";
import { Box } from "@mui/system";
import EditContent from "./Components/EditContent";

const ActivityDetail = () => {
  const navigate = useNavigate();
  const token = useSelector((state) => state.auth.token);
  const { idActivity } = useParams();

  const [isEditing, setIsEditing] = useState(false);
  const [activityDetails, setActivityDetails] = useState(null);
  const [author, setAuthor] = useState({});

  function changeEditHandler() {
    setIsEditing((prev) => !prev);
  }

  useEffect(() => {
    fetch(
      `https://club-management-service.azurewebsites.net/api/v1/events?Id=${idActivity}&includeProperties=Creator.User`,
      {
        headers: {
          Authorization: "Bearer " + token,
        },
      }
    )
      .then((response) => {
        if (response.ok) {
          return response.json();
        }
      })
      .then((resData) => {
        setActivityDetails(resData.data[0]);
        setAuthor(resData.data[0].creator.user);
      })
      .catch((error) => {
        console.log(error);
      });
  }, [idActivity, token]);

  return (
    <Page>
      <Button startIcon={<ArrowBackIosIcon />} onClick={() => navigate(-1)}>
        Back
      </Button>
      <Container>
        <Typography variant="h4" gutterBottom sx={{ mb: 4 }}>
          Activity Detail
        </Typography>

        {activityDetails != null &&
          (isEditing ? (
            <EditContent
              changeEditHandler={changeEditHandler}
              activityDetails={activityDetails}
            />
          ) : (
            <>
              <Card>
                <BlogPostHero
                  activityDetails={activityDetails}
                  author={author}
                />
                <Content activityDetails={activityDetails} />
              </Card>

              <Box
                sx={{ mt: 3, display: "flex", justifyContent: "space-evenly" }}
              >
                <Button
                  variant="contained"
                  color="error"
                  sx={{ mr: 2 }}
                  fullWidth
                >
                  Delete
                </Button>
                <Button
                  variant="contained"
                  sx={{ ml: 2 }}
                  fullWidth
                  onClick={changeEditHandler}
                >
                  Edit
                </Button>
              </Box>
            </>
          ))}
      </Container>
    </Page>
  );
};

export default ActivityDetail;
