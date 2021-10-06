import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  TableFooter,
  TablePagination,
} from "@material-ui/core";
import React, { useState, useEffect } from "react";

const ManageUserForm = () => {
  const [memberData, setMemberData] = useState([]);

  useEffect(() => {
    fetch(
      "https://club-management-service.azurewebsites.net/api/v1/universities",
      {
        headers: {
          Authorization:
            "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imhob2EwOTc4QGdtYWlsLmNvbSIsInVuaXF1ZV9uYW1lIjoiSMOyYSIsIm5iZiI6MTYzMzUyNzgzMiwiZXhwIjoxNjMzOTU5ODMyLCJpYXQiOjE2MzM1Mjc4MzJ9.gKNs-csr4eOdBD4tA-kzLugflhPA91fe-jynXKdPriQ",
        },
      }
    )
      .then((response) => response.json())
      .then((data) => setMemberData(data))
      .catch((error) => {
        throw new Error(error);
      }, []);
  });

  return (
    <div>
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 650 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell align="right">ID</TableCell>
              <TableCell align="right">Name</TableCell>
              <TableCell align="right">Address</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {memberData.map((row) => (
              <TableRow
                key={row.id}
                sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
              >
                <TableCell component="th" scope="row">
                  {row.id}
                </TableCell>
                <TableCell align="right">{row.name}</TableCell>
                <TableCell align="right">{row.address}</TableCell>
              </TableRow>
            ))}
          </TableBody>
          <TableFooter>
            <TableRow>
              <TablePagination
                colSpan={3}
                count={-1}
                rowsPerPage={20}
                page={0}
                rowsPerPageOptions={[5, 10, 25]}
                SelectProps={{
                  inputProps: {
                    "aria-label": "rows per page",
                  },
                  native: true,
                }}
                // onPageChange={handleChangePage}
                // onRowsPerPageChange={handleChangeRowsPerPage}
                // ActionsComponent={TablePaginationActions}
              />
            </TableRow>
          </TableFooter>
        </Table>
      </TableContainer>
    </div>
  );
};

export default ManageUserForm;
