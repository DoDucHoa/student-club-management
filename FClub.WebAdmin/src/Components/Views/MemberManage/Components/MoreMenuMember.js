import { useRef, useState } from "react";

import MoreVertIcon from "@mui/icons-material/MoreVert";

import MonetizationOnIcon from "@mui/icons-material/MonetizationOn";
import PermMediaIcon from "@mui/icons-material/PermMedia";
import PersonIcon from "@mui/icons-material/Person";

// material
import {
  Menu,
  MenuItem,
  IconButton,
  ListItemIcon,
  ListItemText,
  Modal,
  Typography,
  Button,
} from "@mui/material";
import { Box } from "@mui/system";

const style = {
  position: "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: { xs: 300, lg: 350 },
  height: 220,
  bgcolor: "background.paper",
  borderRadius: "20px",
  border: "2px solid #000",
  boxShadow: 24,
  p: 4,
  textAlign: "center",
};

// ----------------------------------------------------------------------

export default function MoreMenuMember({
  userId,
  token,
  refreshHandler,
  memberRole,
}) {
  const ref = useRef(null);
  const [isOpen, setIsOpen] = useState(false);

  const [modalOpen, setModalOpen] = useState(false);
  const modalHandler = () => {
    setModalOpen((prev) => !prev);
  };

  function approveUserHandler() {
    fetch(
      `https://club-management-service.azurewebsites.net/api/v1/members/approved?id=${userId}`,
      {
        method: "PUT",
        headers: {
          Authorization: "Bearer " + token,
        },
      }
    ).then((response) => {
      if (response.ok) {
        refreshHandler();
      }
    });
  }

  function disapproveUserHandler() {
    fetch(
      `https://club-management-service.azurewebsites.net/api/v1/members/${userId}`,
      {
        method: "DELETE",
        headers: {
          Authorization: "Bearer " + token,
        },
      }
    ).then((response) => {
      if (response.ok) {
        refreshHandler();
      }
    });
  }

  return (
    <>
      <IconButton
        ref={ref}
        onClick={() => setIsOpen(true)}
        disabled={memberRole === 1}
      >
        <MoreVertIcon />
      </IconButton>

      <Menu
        open={isOpen}
        anchorEl={ref.current}
        onClose={() => setIsOpen(false)}
        PaperProps={{
          sx: { width: 250, maxWidth: "100%" },
        }}
        anchorOrigin={{ vertical: "top", horizontal: "right" }}
        transformOrigin={{ vertical: "top", horizontal: "right" }}
      >
        {memberRole === 2 && (
          <>
            <MenuItem
              sx={{ color: "text.secondary" }}
              onClick={approveUserHandler}
            >
              <ListItemIcon>
                <MonetizationOnIcon />
              </ListItemIcon>
              <ListItemText
                primary="Promote to Treasurer"
                primaryTypographyProps={{ variant: "body2" }}
              />
            </MenuItem>
            <MenuItem sx={{ color: "text.secondary" }} onClick={setModalOpen}>
              <ListItemIcon>
                <PermMediaIcon />
              </ListItemIcon>
              <ListItemText
                primary="Promote to Creator"
                primaryTypographyProps={{ variant: "body2" }}
              />
            </MenuItem>
          </>
        )}
        {memberRole !== 2 && (
          <MenuItem
            sx={{ color: "text.secondary" }}
            onClick={approveUserHandler}
          >
            <ListItemIcon>
              <PersonIcon />
            </ListItemIcon>
            <ListItemText
              primary="Demote to Member"
              primaryTypographyProps={{ variant: "body2" }}
            />
          </MenuItem>
        )}
      </Menu>

      <Modal
        open={modalOpen}
        onClose={modalHandler}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box sx={style}>
          <Typography id="modal-modal-title" variant="h6" component="h2">
            Confirm
          </Typography>
          <Typography id="modal-modal-description" sx={{ mt: 2 }}>
            Do you really want to <b>disapprove</b> this user?
          </Typography>
          <Box
            sx={{
              display: "flex",
              flexDirection: "row",
              alignItems: "center",
            }}
          >
            <Button
              sx={{ mt: 2, mx: 1 }}
              fullWidth
              variant="contained"
              color="primary"
              onClick={modalHandler}
            >
              Cancel
            </Button>
            <Button
              sx={{ mt: 2, mx: 1 }}
              fullWidth
              variant="contained"
              color="error"
              onClick={disapproveUserHandler}
            >
              Disapprove
            </Button>
          </Box>
        </Box>
      </Modal>
    </>
  );
}
