import GroupIcon from "@mui/icons-material/Group";
import MeetingRoomIcon from "@mui/icons-material/MeetingRoom";

// ----------------------------------------------------------------------

const sidebarConfig = [
  {
    title: "club",
    path: "/dashboard/club",
    icon: <MeetingRoomIcon />,
  },
  {
    title: "manage member",
    path: "/dashboard/user",
    icon: <GroupIcon />,
  },
];

export default sidebarConfig;
