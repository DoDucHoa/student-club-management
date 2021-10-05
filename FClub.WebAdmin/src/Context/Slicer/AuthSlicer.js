import { createSlice } from "@reduxjs/toolkit";
import { auth } from "../../Constants/Firebase";

const initialAuthState = {
  authConfig: auth,
  token: null,
  isLoggedIn: false,
  isLoading: false,
};

const authSlice = createSlice({
  name: "authentication",
  initialState: initialAuthState,
  reducers: {
    replaceAuthConfig(state, action) {
      state.authConfig = action.payload;
    },
    signInHandler(state, action) {
      state.token = action.payload.token;
      localStorage.setItem("token", state.token);
      state.isLoggedIn = true;
    },
    toggleLoading(state) {
      state.isLoading = !state.isLoading;
    },
  },
});

export const authActions = authSlice.actions;
export default authSlice;
