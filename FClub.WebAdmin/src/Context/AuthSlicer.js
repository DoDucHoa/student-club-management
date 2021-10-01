import { createSlice } from "@reduxjs/toolkit";
import { auth } from "../Constants/Firebase";

const initialAuthState = { currentUser: null };

const authSlice = createSlice({
  name: "authentication",
  initialState: initialAuthState,
  reducers: {
    login(state, action) {
      auth.createUserWithEmailAndPassword(
        action.payload.email,
        action.payload.password
      );
    },
  },
});

export default authSlice;
