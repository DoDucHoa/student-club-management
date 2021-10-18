import PropTypes from "prop-types";
// material
import { Grid } from "@mui/material";
import ClubCard from "./ClubCard";

// ----------------------------------------------------------------------

ClubList.propTypes = {
  clubs: PropTypes.array.isRequired,
};

export default function ClubList({ clubs, onBan, ...other }) {
  return (
    <Grid container spacing={3} {...other}>
      {clubs.map((club) => {
        if (club.status === true) {
          return (
            <Grid key={club.id} item xs={12} sm={6} md={3}>
              <ClubCard club={club} onBan={onBan} />
            </Grid>
          );
        } else {
          return null;
        }
      })}
    </Grid>
  );
}
