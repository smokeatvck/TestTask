import { configureStore } from "@reduxjs/toolkit";
import reducer from "./postReducer";

export const store = configureStore({
  reducer,
});
