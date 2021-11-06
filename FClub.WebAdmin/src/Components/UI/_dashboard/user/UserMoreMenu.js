import { useRef, useState } from "react";
import { Link as RouterLink } from "react-router-dom";

import MoreVertIcon from "@mui/icons-material/MoreVert";
import BlockIcon from "@mui/icons-material/Block";
import ArrowCircleUpIcon from "@mui/icons-material/ArrowCircleUp";

// material
import {
  Menu,
  MenuItem,
  IconButton,
  ListItemIcon,
  ListItemText,
} from "@mui/material";

// ----------------------------------------------------------------------

export default function UserMoreMenu({
  userId,
  isAdmin,
  token,
  refreshHandler,
}) {
  const ref = useRef(null);
  const [isOpen, setIsOpen] = useState(false);

  function disableUserHandler() {
    fetch(
      `https://club-management-service.azurewebsites.net/api/v1/users/${userId}/false`,
      {
        method: "PUT",
        headers: {
          Authorization: "Bearer " + token,
        },
      }
    )
      .then((response) => {
        if (response.ok) {
          refreshHandler();
        }
      })
      .catch((error) => console.log(error));
  }

  return (
    <>
      <IconButton ref={ref} onClick={() => setIsOpen(true)} disabled={isAdmin}>
        <MoreVertIcon />
      </IconButton>

      <Menu
        open={isOpen}
        anchorEl={ref.current}
        onClose={() => setIsOpen(false)}
        PaperProps={{
          sx: { width: 200, maxWidth: "100%" },
        }}
        anchorOrigin={{ vertical: "top", horizontal: "right" }}
        transformOrigin={{ vertical: "top", horizontal: "right" }}
      >
        <MenuItem sx={{ color: "text.secondary" }} onClick={disableUserHandler}>
          <ListItemIcon>
            <BlockIcon />
          </ListItemIcon>
          <ListItemText
            primary="Disable User"
            primaryTypographyProps={{ variant: "body2" }}
          />
        </MenuItem>
        <MenuItem
          component={RouterLink}
          to="#"
          sx={{ color: "text.secondary" }}
        >
          <ListItemIcon>
            <ArrowCircleUpIcon />
          </ListItemIcon>
          <ListItemText
            primary="Promote To Admin"
            primaryTypographyProps={{ variant: "body2" }}
          />
        </MenuItem>
      </Menu>
    </>
  );
}
