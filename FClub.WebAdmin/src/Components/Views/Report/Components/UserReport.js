import { Card } from "@mui/material";
import React, { useState, useEffect } from "react";
import { Bar } from "react-chartjs-2";
import { useSelector } from "react-redux";

const UserReport = () => {
  const token = useSelector((state) => state.auth.token);
  const [userName, setUserName] = useState([]);
  const [value, setValue] = useState([]);

  useEffect(() => {
    fetch(
      "https://club-management-service.azurewebsites.net/api/v1/users/rank",
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
        setValue(data.map((user) => user.value));
        setUserName(data.map((user) => user.key.name));
      })
      .catch((error) => {
        console.log(error.code);
      });
  }, [token]);

  return (
    <Card sx={{ p: 3 }}>
      <Bar
        data={{
          labels: userName,
          datasets: [
            {
              label: "# of joined clubs",
              data: value,
              backgroundColor: "#D7ECFB",
              borderColor: "#64B7EF",
              hoverBorderColor: "black",
              borderWidth: 2,
            },
          ],
        }}
        options={{
          indexAxis: "y",
          plugins: {
            title: {
              text: "User who joins the most clubs",
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

export default UserReport;
