import GroupsIcon from "@mui/icons-material/Groups";
import ManageSearchIcon from "@mui/icons-material/ManageSearch";
import AttachMoneyIcon from "@mui/icons-material/AttachMoney";
import NotificationsActiveIcon from "@mui/icons-material/NotificationsActive";
import LogoutIcon from "@mui/icons-material/Logout";

export const menuItems = [
  {
    text: "Manage User",
    icon: <GroupsIcon color="primary" />,
    path: "/manage-user",
  },
  {
    text: "Manage Club",
    icon: <ManageSearchIcon color="primary" />,
    path: "/",
  },
  {
    text: "Activities",
    icon: <NotificationsActiveIcon color="primary" />,
    path: "/",
  },
  {
    text: "Budget",
    icon: <AttachMoneyIcon color="primary" />,
    path: "/",
  },
  {
    text: "Sign Out",
    icon: <LogoutIcon color="primary" />,
    path: "/",
  },
];
