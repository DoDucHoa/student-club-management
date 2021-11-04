import React from "react";
import { Link as RouterLink } from "react-router-dom";
import { fVNDate } from "../../../../Utils/formatTime";

// materials
import {
  Card,
  CardActionArea,
  CardMedia,
  CardContent,
  Typography,
  CardActions,
  Button,
  CardHeader,
} from "@mui/material";

// components
import CreatorAvartar from "./CreatorAvartar";
import { Box } from "@mui/system";

const ActivityCard = ({ activity }) => {
  const { id, image, title, content, createDate } = activity;
  const { name, photo } = activity.creator.user;

  function cutString(text) {
    if (text.length < 65) {
      return text;
    }
    return text.substring(0, 63) + "...";
  }

  return (
    <Card>
      <CardActionArea>
        <RouterLink
          to={`${id}`}
          style={{ textDecoration: "inherit", color: "inherit" }}
        >
          <CardMedia component="img" height="200" image={image} alt={title} />
          <CardContent sx={{ minHeight: { md: 130, lg: 160, xl: 130 } }}>
            <Typography gutterBottom variant="h5" component="div">
              {title}
            </Typography>
            <Typography variant="body2" color="text.secondary">
              {cutString(content)}
            </Typography>
          </CardContent>
        </RouterLink>
      </CardActionArea>
      <CardHeader
        avatar={<CreatorAvartar photo={photo} />}
        title={name}
        subheader={"Created: " + fVNDate(createDate)}
      />
      <Box
        sx={{
          display: "flex",
          flexDirection: "row",
          justifyContent: "flex-end",
        }}
      >
        <CardActions>
          <Button size="small" color="error">
            Delete
          </Button>
        </CardActions>
        <CardActions>
          <Button size="small">Edit</Button>
        </CardActions>
      </Box>
    </Card>
  );
};

export default ActivityCard;
