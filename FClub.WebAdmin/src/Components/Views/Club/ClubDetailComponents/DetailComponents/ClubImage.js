import { Button, Card, CardContent, Modal, Typography } from "@mui/material";
import React, { useState } from "react";
import { styled } from "@mui/material/styles";
import { Box } from "@mui/system";
import PropTypes from "prop-types";
import { useSelector } from "react-redux";

const ImageContaier = styled("div")(({ theme }) => ({
  margin: "auto",
  borderRadius: "50%",
  padding: "15px",
  border: "1px",
}));

const ImageHolder = styled("div")(({ theme }) => ({
  width: "100%",
  height: "100%",
  outline: "none",
  display: "flex",
  overflow: "hidden",
  borderRadius: "50%",
  position: "relative",
  alignItems: "center",
  justifyContent: "center",
}));

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

const ClubImage = ({ imageSrc, title, onBan, name, id }) => {
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
        <ImageContaier>
          <ImageHolder>
            <img src={imageSrc} alt="Ava" />
          </ImageHolder>
        </ImageContaier>
        <CardContent>
          <Box sx={{ textAlign: "center" }}>
            <Typography variant="h4" sx={{ mb: 2 }}>
              {title}
            </Typography>
            <Button variant="contained" color="error">
              Ban this Club
            </Button>
          </Box>
        </CardContent>
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
};

export default ClubImage;

ClubImage.propTypes = {
  title: PropTypes.string,
  imageSrc: PropTypes.string,
  onBan: PropTypes.func,
  name: PropTypes.string,
  id: PropTypes.string,
};
