import React from "react";

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
  function cardClickHandler() {
    console.log(1);
  }

  function cutString(text) {
    if (text.length < 65) {
      return text;
    }
    return text.substring(0, 63) + "...";
  }

  return (
    <Card>
      <CardActionArea onClick={cardClickHandler}>
        <CardMedia
          component="img"
          height="200"
          image={activity.image}
          alt={activity.title}
        />
        <CardContent sx={{ minHeight: { md: 130, lg: 160, xl: 130 } }}>
          <Typography gutterBottom variant="h5" component="div">
            {activity.title}
          </Typography>
          <Typography variant="body2" color="text.secondary">
            {cutString(activity.content)}
          </Typography>
        </CardContent>
      </CardActionArea>
      <CardHeader
        avatar={<CreatorAvartar creatorId={activity.creatorId} />}
        title="Đỗ Đức Hòa"
        subheader="September 14, 2016"
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
