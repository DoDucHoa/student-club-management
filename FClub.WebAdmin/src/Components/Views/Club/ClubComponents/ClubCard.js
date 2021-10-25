import React, { useState } from "react";
import { useSelector } from "react-redux";

import PropTypes from "prop-types";
import { Link as RouterLink } from "react-router-dom";
// material
import {
  Box,
  Card,
  Typography,
  Stack,
  Button,
  Modal,
  CardActionArea,
} from "@mui/material";
import { styled } from "@mui/material/styles";

// ----------------------------------------------------------------------

const ClubImgStyle = styled("img")({
  top: 0,
  width: "100%",
  height: "100%",
  objectFit: "cover",
  position: "absolute",
});

const style = {
  position: "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: { xs: 300, lg: 350 },
  height: 250,
  bgcolor: "background.paper",
  borderRadius: "20px",
  border: "2px solid #000",
  boxShadow: 24,
  p: 4,
};

// ----------------------------------------------------------------------

ClubCard.propTypes = {
  club: PropTypes.object,
};

export default function ClubCard({ club, onBan }) {
  const { id, name, logo } = club;

  return (
    <>
      <Card>
        <CardActionArea>
          <RouterLink
            style={{ textDecoration: "none", color: "black" }}
            to={id}
          >
            <Box sx={{ pt: "100%", position: "relative" }}>
              <ClubImgStyle alt={name} src={logo} />
            </Box>

            <Stack
              spacing={2}
              sx={{ p: 3, textAlign: "center", alignItems: "center" }}
            >
              <Typography variant="subtitle2" noWrap>
                {name}
              </Typography>
            </Stack>
          </RouterLink>
        </CardActionArea>
      </Card>
    </>
  );
}
