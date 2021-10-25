export async function GetClubDetails(token, clubId) {
  try {
    const response = await fetch(
      "https://club-management-service.azurewebsites.net/api/v1/clubs?id=" +
        clubId,
      {
        headers: {
          Authorization: "Bearer " + token,
        },
      }
    );
    if (response.ok) {
      const data = await response.json();
      return data[0];
    }
  } catch (error) {
    console.log(error);
  }
}
