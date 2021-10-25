import React, { useState, useEffect } from "react";
import { useSelector } from "react-redux";
import { useParams } from "react-router-dom";

// materials
import { Container, Grid, Typography } from "@mui/material";

// components
import Page from "../../../UI/Page";
import ClubImage from "./DetailComponents/ClubImage";
import ClubInfo from "./DetailComponents/ClubInfo";
import { GetClubDetails } from "./DetailComponents/action";

const ClubDetail = () => {
  const token = useSelector((state) => state.auth.token);
  const { id: clubId } = useParams();

  const [clubDetails, setClubDetails] = useState({});

  useEffect(() => {
    GetClubDetails(token, clubId).then((data) => setClubDetails(data));
  }, [token, clubId]);

  const { id, name, logo, about } = clubDetails;

  return (
    <Page title="Club Details">
      <Container>
        <Typography variant="h4" sx={{ mb: 5 }}>
          Club Details
        </Typography>
        <Grid container spacing={3}>
          <Grid item xs={12} sm={5} md={4}>
            <ClubImage title={name} imageSrc={logo} />
          </Grid>
          <Grid item xs={12} sm={7} md={8}>
            <ClubInfo key={id} clubName={name} about={about} />
          </Grid>
        </Grid>
      </Container>
    </Page>
  );
};

export default ClubDetail;
