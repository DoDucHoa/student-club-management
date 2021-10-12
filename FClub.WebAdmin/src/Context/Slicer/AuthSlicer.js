import { createSlice } from "@reduxjs/toolkit";

const retrieveStoredToken = () => {
  const storedToken = localStorage.getItem("token");
  return storedToken;
};

const retrieveStoredUserId = () => {
  const storedUserId = localStorage.getItem("userId");
  return storedUserId;
};

const retrieveStoredUserData = () => {
  const storedUserData = JSON.parse(localStorage.getItem("userData"));
  return storedUserData;
};

const removeToken = () => {
  localStorage.clear();
};

const initialAuthState = {
  token: retrieveStoredToken(),
  userId: retrieveStoredUserId(),
  userData: retrieveStoredUserData(),
  isLoggedIn: !!retrieveStoredToken(),
  isLoading: false,
};

const authSlice = createSlice({
  name: "authentication",
  initialState: initialAuthState,
  reducers: {
    signInHandler(state, action) {
      state.token = action.payload.token;
      state.userId = action.payload.userData.id;
      state.userData = action.payload.userData;
      localStorage.setItem("token", state.token);
      localStorage.setItem("userId", state.userId);
      localStorage.setItem("userData", JSON.stringify(state.userData));
      state.isLoggedIn = true;
    },
    signOutHandler(state) {
      state.token = "";
      state.isLoggedIn = false;
      state.userId = 0;
      state.userData = {};
      removeToken();
    },
    toggleLoading(state) {
      state.isLoading = !state.isLoading;
    },
  },
});

export const authActions = authSlice.actions;
export default authSlice;
