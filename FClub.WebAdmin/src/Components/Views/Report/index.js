import React from "react";

// materials
import { Container, Typography, Grid } from "@mui/material";

import Page from "../../UI/Page";
import UserReport from "./Components/UserReport";
import ClubReport from "./Components/ClubReport";

const ReportBody = () => {
  return (
    <Page title="Report">
      <Container>
        <Typography variant="h4" gutterBottom sx={{ mb: 3 }}>
          Report
        </Typography>

        <Grid container spacing={3}>
          <Grid item xs={12} md={6}>
            <UserReport />
          </Grid>
          <Grid item xs={12} md={6}>
            <ClubReport />
          </Grid>
        </Grid>
      </Container>
    </Page>
  );
};

export default ReportBody;
