import { configureStore } from "@reduxjs/toolkit";
import authSlice from "./Slicer/AuthSlicer";

const store = configureStore({
  reducer: { auth: authSlice.reducer },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({ serializableCheck: false }),
});

export default store;
