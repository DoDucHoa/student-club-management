import React from "react";
import { useDispatch } from "react-redux";

// component
import { signOutWeb } from "../Context/Actions/authen-action";

// mui style
import { makeStyles } from "@mui/styles";
import {
  Drawer,
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
  Typography,
  Divider,
  ListItemButton,
} from "@mui/material";

import { menuItems } from "../Constants/MenuItems";
import { Outlet, useLocation } from "react-router";

// icons
import LogoutIcon from "@mui/icons-material/Logout";

const useStyled = makeStyles({
  root: {
    display: "flex",
  },
  page: {
    width: "100%",
    background: "#ffffff",
  },
  drawer: {
    width: "240px",
  },
  drawerPaper: {
    width: 240,
  },
  active: {
    background: "#f4f4f4",
  },
});

const DashBoardLayout = ({ children }) => {
  const classes = useStyled();
  const location = useLocation();

  const dispatch = useDispatch();

  const signOutHandler = () => {
    dispatch(signOutWeb());
  };

  return (
    <div className={classes.root}>
      <Drawer
        open={true}
        className={classes.drawer}
        classes={{ paper: classes.drawerPaper }}
        variant="persistent"
        anchor="left"
      >
        <div>
          <Typography variant="h5">Cluber</Typography>
        </div>

        <List>
          {menuItems.map((item) => (
            <ListItem
              className={
                location.pathname === item.path ? classes.active : null
              }
              button
              key={item.text}
            >
              <ListItemIcon>{item.icon}</ListItemIcon>
              <ListItemText>{item.text}</ListItemText>
            </ListItem>
          ))}
          <Divider />
          <ListItemButton onClick={signOutHandler}>
            <ListItemIcon>
              <LogoutIcon color="primary" />
            </ListItemIcon>
            <ListItemText>Sign Out</ListItemText>
          </ListItemButton>
        </List>
      </Drawer>
      <div className={classes.page}>
        <Outlet />
      </div>
    </div>
  );
};

export default DashBoardLayout;
