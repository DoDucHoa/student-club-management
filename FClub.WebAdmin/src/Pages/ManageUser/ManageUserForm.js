import React, { useState, useEffect } from "react";
import MaterialTable from "material-table";
import { tableIcons } from "../../Constants/MaterialTableIcon";

const ManageUserForm = () => {
  const [memberData, setMemberData] = useState([]);

  useEffect(() => {
    fetch("https://club-management-service.azurewebsites.net/api/universities")
      .then((response) => console.log(response))
      .then((data) => setMemberData(data))
      .catch((error) => {
        throw new Error(error);
      }, []);
  });

  const columns = [
    { field: "id", title: "School ID", width: "20%" },
    { field: "name", title: "School Name", width: "30%" },
    { field: "address", title: "Address", width: "50%" },
  ];

  return (
    <div>
      <MaterialTable
        icons={tableIcons}
        columns={columns}
        data={memberData}
        title="School Information"
        options={{ tableLayout: "auto" }}
      />
    </div>
  );
};

export default ManageUserForm;
