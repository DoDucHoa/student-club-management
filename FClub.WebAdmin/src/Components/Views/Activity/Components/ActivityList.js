import React, { useState, useEffect } from "react";

import { useSelector } from "react-redux";

// material
import { Grid } from "@mui/material";

// components
import ActivityCard from "./ActivityCard";

// ----------------------------------------------------------------------

export default function ActivityList({ ...other }) {
  const token = useSelector((state) => state.auth.token);
  const [activities, setActivities] = useState([]);

  useEffect(() => {
    fetch(
      "https://club-management-service.azurewebsites.net/api/v1/events?includeProperties=Creator.User",
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
      .then((responseData) => {
        setActivities(responseData.data);
      });
  }, [token]);

  return (
    <Grid container spacing={3} {...other}>
      {activities.map((activity) => {
        if (activity.status === true) {
          return (
            <Grid key={activity.id} item xs={12} sm={6} md={4}>
              <ActivityCard activity={activity} />
            </Grid>
          );
        } else {
          return null;
        }
      })}
    </Grid>
  );
}
