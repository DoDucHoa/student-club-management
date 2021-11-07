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
import BanMemberModal from "./BanMemberModal";

// ----------------------------------------------------------------------

export default function MoreMenuMember({
  userId,
  token,
  refreshHandler,
  memberRole,
}) {
  const ref = useRef(null);
  const [isOpen, setIsOpen] = useState(false);

  const [modalDisapproveOpen, setModalDisapproveOpen] = useState(false);
  const [modalBanOpen, setModalBanOpen] = useState(false);

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
            <MenuItem
              sx={{ color: "text.secondary" }}
              onClick={setModalDisapproveOpen}
            >
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
        <MenuItem sx={{ color: "text.secondary" }} onClick={setModalBanOpen}>
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
        modalOpen={modalDisapproveOpen}
        setModalOpen={setModalDisapproveOpen}
        refreshHandler={refreshHandler}
      />

      <BanMemberModal
        token={token}
        userId={userId}
        modalOpen={modalBanOpen}
        setModalOpen={setModalBanOpen}
        refreshHandler={refreshHandler}
      />
    </>
  );
}
