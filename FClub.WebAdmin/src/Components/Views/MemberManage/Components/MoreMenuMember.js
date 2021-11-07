import { useRef, useState } from "react";

import MoreVertIcon from "@mui/icons-material/MoreVert";

import MonetizationOnIcon from "@mui/icons-material/MonetizationOn";
import PermMediaIcon from "@mui/icons-material/PermMedia";
import PersonIcon from "@mui/icons-material/Person";
import NotInterestedIcon from "@mui/icons-material/NotInterested";

// material
import {
  Menu,
  MenuItem,
  IconButton,
  ListItemIcon,
  ListItemText,
} from "@mui/material";
import DisapproveModal from "./DisapproveModal";

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

  function banMemberHandler() {
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
        <MenuItem sx={{ color: "text.secondary" }} onClick={banMemberHandler}>
          <ListItemIcon>
            <NotInterestedIcon />
          </ListItemIcon>
          <ListItemText
            primary="Ban member"
            primaryTypographyProps={{ variant: "body2" }}
          />
        </MenuItem>
      </Menu>

      <DisapproveModal
        token={token}
        userId={userId}
        modalOpen={modalOpen}
        setModalOpen={setModalOpen}
        refreshHandler={refreshHandler}
      />
    </>
  );
}
