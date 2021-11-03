import { useRef, useState } from "react";
import { Link as RouterLink } from "react-router-dom";

import MoreVertIcon from "@mui/icons-material/MoreVert";

import ThumbUpIcon from "@mui/icons-material/ThumbUp";
import DoNotDisturbOnIcon from "@mui/icons-material/DoNotDisturbOn";

// material
import {
  Menu,
  MenuItem,
  IconButton,
  ListItemIcon,
  ListItemText,
} from "@mui/material";

// ----------------------------------------------------------------------

export default function MoreMenuApprove({ userId, token, refreshHandler }) {
  const ref = useRef(null);
  const [isOpen, setIsOpen] = useState(false);

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
        //window.location.reload(false);
        refreshHandler();
      }
    });
  }

  return (
    <>
      <IconButton ref={ref} onClick={() => setIsOpen(true)}>
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
        <MenuItem sx={{ color: "text.secondary" }} onClick={approveUserHandler}>
          <ListItemIcon>
            <ThumbUpIcon />
          </ListItemIcon>
          <ListItemText
            primary="Approve"
            primaryTypographyProps={{ variant: "body2" }}
          />
        </MenuItem>
        <MenuItem
          component={RouterLink}
          to="#"
          sx={{ color: "text.secondary" }}
        >
          <ListItemIcon>
            <DoNotDisturbOnIcon />
          </ListItemIcon>
          <ListItemText
            primary="Disapprove"
            primaryTypographyProps={{ variant: "body2" }}
          />
        </MenuItem>
      </Menu>
    </>
  );
}
