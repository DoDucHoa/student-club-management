export async function GetMemberId(token, userId, clubId) {
  try {
    const response = await fetch(
      `https://club-management-service.azurewebsites.net/api/v1/members?UserId=${userId}&ClubId=${clubId}`,
      {
        headers: {
          Authorization: "Bearer " + token,
        },
      }
    );
    if (response.ok) {
      const responseData = await response.json();
      if (responseData.length !== 0) {
        return responseData.data[0].id;
      }
    }
  } catch (error) {
    console.log(error);
  }
}
