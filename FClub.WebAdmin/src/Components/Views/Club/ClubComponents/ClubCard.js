import React, { useState } from "react";

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

import { getStorage, ref, getDownloadURL } from "firebase/storage";

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

export default function ClubCard({ club }) {
  const { id, name, logo } = club;

  const [modalOpen, setModalOpen] = useState(false);
  const [logoUrl, setLogoUrl] = useState("");

  if (!!logo) {
    const storage = getStorage();
    getDownloadURL(ref(storage, logo))
      .then((url) => {
        setLogoUrl(url);
      })
      .catch((error) => {
        console.log(error);
      });
  }

  const modalHandler = () => {
    setModalOpen((prev) => !prev);
  };

  return (
    <>
      <Card>
        <Box sx={{ pt: "100%", position: "relative" }}>
          <ClubImgStyle alt={name} src={logoUrl} />
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
          <Button variant="contained" fullWidth onClick={modalHandler}>
            Join Club
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
              Join {name}?
            </Typography>
            <Button
              sx={{ mt: 2 }}
              fullWidth
              variant="contained"
              color="primary"
              onClick={modalHandler}
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
