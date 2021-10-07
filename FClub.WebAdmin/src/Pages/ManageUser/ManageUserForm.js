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
  const [page, setPage] = useState(1);

  useEffect(() => {
    fetch(
      "https://club-management-service.azurewebsites.net/api/v1/universities?PageNumber=" +
        page,
      {
        headers: {
          Authorization:
            "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imhob2EwOTc4QGdtYWlsLmNvbSIsInVuaXF1ZV9uYW1lIjoiSMOyYSIsIm5iZiI6MTYzMzUyNzgzMiwiZXhwIjoxNjMzOTU5ODMyLCJpYXQiOjE2MzM1Mjc4MzJ9.gKNs-csr4eOdBD4tA-kzLugflhPA91fe-jynXKdPriQ",
        },
      }
    )
      .then((response) => {
        console.log(response.headers.get("X-Pagination"));
        return response.json();
      })
      .then((data) => setMemberData(data))
      .catch((error) => {
        throw new Error(error);
      }, []);
  }, [page]);

  const handleChangePage = (event, newPage) => {
    if (newPage <= 0) {
      newPage = 1;
    }
    setPage(newPage);
    console.log(newPage);
  };

  return (
    <TableContainer component={Paper}>
      <Table>
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
              rowsPerPageOptions={[5, 10, 25]}
              colSpan={3}
              count={-1}
              rowsPerPage={20}
              page={page}
              SelectProps={{
                inputProps: {
                  "aria-label": "rows per page",
                },
                native: true,
              }}
              onPageChange={handleChangePage}
              // onRowsPerPageChange={handleChangeRowsPerPage}
              // ActionsComponent={TablePaginationActions}
            />
          </TableRow>
        </TableFooter>
      </Table>
    </TableContainer>
  );
};

export default ManageUserForm;
