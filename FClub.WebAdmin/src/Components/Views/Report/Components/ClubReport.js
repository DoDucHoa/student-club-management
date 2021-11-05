import React, { useState, useEffect } from "react";
import { Card } from "@mui/material";
import { Bar } from "react-chartjs-2";
import { useSelector } from "react-redux";

const ClubReport = () => {
  const token = useSelector((state) => state.auth.token);
  const [clubName, setClubName] = useState([]);
  const [value, setValue] = useState([]);

  useEffect(() => {
    fetch(
      "https://club-management-service.azurewebsites.net/api/v1/clubs/rank",
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
      .then((data) => {
        setValue(data.map((club) => club.value));
        setClubName(data.map((club) => club.key.name));
      })
      .catch((error) => {
        console.log(error.code);
      });
  }, [token]);

  return (
    <Card sx={{ p: 3 }}>
      <Bar
        data={{
          labels: clubName,
          datasets: [
            {
              label: "# of members",
              data: value,
              backgroundColor: "#DBF2F2",
              borderColor: "#4BC0C0",
              hoverBorderColor: "black",
              borderWidth: 2,
            },
          ],
        }}
        options={{
          scales: {
            y: {
              ticks: {
                stepSize: 1,
              },
            },
          },
          plugins: {
            title: {
              text: "Club with the most members",
              display: true,
              fullSize: true,
            },
          },
        }}
        height={400}
        width={600}
      />
    </Card>
  );
};

export default ClubReport;
