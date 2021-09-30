import React from "react";

import { makeStyles } from "@mui/styles";
import {
  Drawer,
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
  Typography,
} from "@mui/material";

import { menuItems } from "../Constants/MenuItems";
import { useLocation } from "react-router";

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

  return (
    <div className={classes.root}>
      <Drawer
        className={classes.drawer}
        classes={{ paper: classes.drawerPaper }}
        variant="permanent"
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
        </List>
      </Drawer>
      <div className={classes.page}>{children}</div>
    </div>
  );
};

export default DashBoardLayout;
