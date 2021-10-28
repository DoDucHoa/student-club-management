import React, { useState, useEffect } from "react";
import { useSelector } from "react-redux";

// component
import Page from "../../UI/Page";
import ClubList from "./ClubComponents/ClubList";

// material
import { Container, Typography } from "@mui/material";

const ClubComponent = () => {
  const token = useSelector((state) => state.auth.token);

  const [clubs, setClubs] = useState([]);

  const url =
    "https://club-management-service.azurewebsites.net/api/v1/clubs?PageSize=100";

  useEffect(() => {
    fetch(url, {
      headers: {
        Authorization: "Bearer " + token,
      },
    })
      .then((res) => {
        if (res.ok) {
          return res.json();
        } else {
          throw new Error(res.statusText);
        }
      })
      .then((resData) => {
        setClubs(resData);
      })
      .catch((err) => {
        console.log(err);
      });
  }, [url, token]);

  return (
    <Page title="Club">
      <Container>
        <Typography variant="h4" sx={{ mb: 5 }}>
          Clubs
        </Typography>

        <ClubList clubs={clubs} />
      </Container>
    </Page>
  );
};

export default ClubComponent;
