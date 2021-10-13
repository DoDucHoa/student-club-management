import React, { useState } from "react";
import { useSelector } from "react-redux";

import PropTypes from "prop-types";
import { Link as RouterLink } from "react-router-dom";
// material
import {
  Box,
  Card,
  Link,
  Typography,
  Stack,
  Button,
  Modal,
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

  const token = useSelector((state) => state.auth.token);

  const [modalOpen, setModalOpen] = useState(false);

  const modalHandler = () => {
    setModalOpen((prev) => !prev);
  };

  const banClubHandler = (event) => {
    const id = event.target.id;
    const url = `https://club-management-service.azurewebsites.net/api/v1/clubs/${id}/false`;
    fetch(url, {
      method: "PUT",
      headers: {
        Authorization: "Bearer " + token,
      },
    }).catch((err) => {
      console.log(err);
    });
    setModalOpen((prev) => !prev);
    onBan(id);
  };

  return (
    <>
      <Card>
        <Box sx={{ pt: "100%", position: "relative" }}>
          <ClubImgStyle alt={name} src={logo} />
        </Box>

        <Stack
          spacing={2}
          sx={{ p: 3, textAlign: "center", alignItems: "center" }}
        >
          <Link to="#" color="inherit" underline="hover" component={RouterLink}>
            <Typography variant="subtitle2" noWrap>
              {name}
            </Typography>
          </Link>
          <Button variant="contained" fullWidth>
            Detail
          </Button>
          <Button
            variant="contained"
            color="error"
            fullWidth
            onClick={modalHandler}
          >
            Ban Club
          </Button>
        </Stack>
      </Card>

      <Modal
        open={modalOpen}
        onClose={modalHandler}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box sx={style}>
          <Box
            sx={{
              display: "flex",
              flexDirection: "column",
              alignItems: "center",
              justifyContent: "center",
            }}
          >
            <Typography id="modal-modal-title" variant="h6" component="h2">
              Confirm
            </Typography>
            <Typography id="modal-modal-description" sx={{ mt: 2 }}>
              Ban {name}?
            </Typography>
            <Button
              sx={{ mt: 2 }}
              fullWidth
              variant="contained"
              color="primary"
              id={id}
              onClick={banClubHandler}
            >
              Yes
            </Button>
            <Button
              sx={{ mt: 2 }}
              fullWidth
              variant="contained"
              color="error"
              onClick={modalHandler}
            >
              No
            </Button>
          </Box>
        </Box>
      </Modal>
    </>
  );
}
