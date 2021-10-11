import { createSlice } from "@reduxjs/toolkit";

const retrieveStoredToken = () => {
  const storedToken = localStorage.getItem("token");
  return storedToken;
};

const removeToken = () => {
  localStorage.clear();
};

const initialAuthState = {
  token: retrieveStoredToken(),
  isLoggedIn: !!retrieveStoredToken(),
  isLoading: false,
};

const authSlice = createSlice({
  name: "authentication",
  initialState: initialAuthState,
  reducers: {
    signInHandler(state, action) {
      state.token = action.payload.token;
      localStorage.setItem("token", state.token);
      state.isLoggedIn = true;
    },
    signOutHandler(state) {
      state.token = "";
      state.isLoggedIn = false;
      removeToken();
    },
    toggleLoading(state) {
      state.isLoading = !state.isLoading;
    },
  },
});

export const authActions = authSlice.actions;
export default authSlice;
