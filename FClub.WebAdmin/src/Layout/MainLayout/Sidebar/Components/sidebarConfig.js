import GroupIcon from "@mui/icons-material/Group";
import MeetingRoomIcon from "@mui/icons-material/MeetingRoom";
import NotificationsActiveIcon from "@mui/icons-material/NotificationsActive";

// ----------------------------------------------------------------------

const sidebarConfig = [
  {
    title: "manage club",
    path: "/dashboard/club",
    icon: <MeetingRoomIcon />,
  },
  {
    title: "manage User",
    path: "/dashboard/user",
    icon: <GroupIcon />,
  },
  {
    title: "Activities",
    path: "/dashboard/activity",
    icon: <NotificationsActiveIcon />,
  },
];

export default sidebarConfig;
