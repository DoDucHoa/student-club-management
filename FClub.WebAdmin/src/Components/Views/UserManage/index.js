import React from "react";
import { useSelector } from "react-redux";

import { Container, Divider, Typography } from "@mui/material";
import Page from "../../UI/Page";
import ActiveUserList from "./Components/UserManageComponent";
import InactiveUserList from "./Components/InactiveUserList";

const UserManage = () => {
  const token = useSelector((state) => state.auth.token);

  return (
    <Page title="User Management">
      <Container>
        <Typography variant="h4" gutterBottom>
          Users Management
        </Typography>
        <ActiveUserList token={token} />
        <Divider sx={{ my: 5 }} />
        <Typography variant="h4" gutterBottom>
          Inactive User
        </Typography>
        <InactiveUserList token={token} />
      </Container>
    </Page>
  );
};

export default UserManage;
