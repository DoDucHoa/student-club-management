import PieChartIcon from "@mui/icons-material/PieChart";
import GroupIcon from "@mui/icons-material/Group";

// ----------------------------------------------------------------------

const sidebarConfig = [
  {
    title: "dashboard",
    path: "/dashboard/app",
    icon: <PieChartIcon />,
  },
  {
    title: "manage user",
    path: "/dashboard/user",
    icon: <GroupIcon />,
  },
];

export default sidebarConfig;
