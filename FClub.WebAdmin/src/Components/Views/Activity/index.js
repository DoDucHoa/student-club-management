import React from "react";

// component
import Page from "../../UI/Page";

// material
import { Container, Typography } from "@mui/material";

// ------------------------------------------------------

const ActivityComponents = () => {
  return (
    <Page title="Club">
      <Container>
        <Typography variant="h4" sx={{ mb: 5 }}>
          Activities
        </Typography>
      </Container>
    </Page>
  );
};

export default ActivityComponents;
