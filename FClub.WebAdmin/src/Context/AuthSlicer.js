import { createSlice } from "@reduxjs/toolkit";

const initialAuthState = { currentUser: null };

const authSlice = createSlice({
  name: "authentication",
  initialState: initialAuthState,
  reducers: {
    login(state, action) {},
  },
});

export default authSlice;
