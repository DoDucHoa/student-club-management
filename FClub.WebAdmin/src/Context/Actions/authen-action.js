import { authActions } from "../Slicer/AuthSlicer";

// firebase
import { auth } from "../../Constants/Firebase";
import {
  createUserWithEmailAndPassword,
  signInWithEmailAndPassword,
} from "firebase/auth";

export const signUp = (email, password) => {
  return async (dispatch) => {
    try {
      const userCredential = await createUserWithEmailAndPassword(
        auth,
        email,
        password
      );
      console.log(userCredential.user);
    } catch (err) {
      console.log(err.code);
      console.log(err.message);
    }
  };
};

export const signIn = (email, password) => {
  return async (dispatch) => {
    try {
      dispatch(authActions.toggleLoading());
      const userCredential = await signInWithEmailAndPassword(
        auth,
        email,
        password
      );
      dispatch(authActions.toggleLoading());
      dispatch(
        authActions.signInHandler({
          token: userCredential.user.accessToken,
        })
      );
    } catch (err) {
      console.log(err.code);
    }
  };
};
