import React from "react";

// materials
import { Container, Typography, Grid, Card } from "@mui/material";

// chart.js
import { Bar } from "react-chartjs-2";

import Page from "../../UI/Page";

const ReportBody = () => {
  return (
    <Page title="Report">
      <Container>
        <Typography variant="h4" gutterBottom sx={{ mb: 3 }}>
          Report
        </Typography>

        <Grid container spacing={3}>
          <Grid item xs={12} md={6}>
            <Card sx={{ p: 3 }}>
              <Bar
                data={{
                  labels: ["Red", "Blue", "Yellow", "Green", "Purple"],
                  datasets: [
                    {
                      label: "Clubs join",
                      data: [19, 15, 8, 5, 2],
                    },
                  ],
                }}
                options={{
                  indexAxis: "y",
                }}
                height={200}
                width={400}
              />
            </Card>
          </Grid>
          <Grid item xs={12} md={6}>
            <Card sx={{ p: 3 }}>
              <Bar
                data={{
                  labels: ["Red", "Blue", "Yellow", "Green", "Purple"],
                  datasets: [
                    {
                      label: "Clubs join",
                      data: [19, 15, 8, 5, 2],
                      backgroundColor: ["rgba(255, 99, 132, 0.2)"],
                    },
                  ],
                }}
                height={200}
                width={400}
              />
            </Card>
          </Grid>
        </Grid>
      </Container>
    </Page>
  );
};

export default ReportBody;
