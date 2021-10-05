import { authActions } from "../Slicer/AuthSlicer";
import { errorActions } from "../Slicer/ErrorSlicer";

// firebase
import { auth } from "../../Constants/Firebase";
import {
  createUserWithEmailAndPassword,
  signInWithEmailAndPassword,
  GoogleAuthProvider,
  signInWithPopup,
} from "firebase/auth";

export const signUp = (email, password) => {
  return async (dispatch) => {
    try {
      dispatch(authActions.toggleLoading());
      const userCredential = await createUserWithEmailAndPassword(
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
      dispatch(errorActions.turnOffError());

      dispatch(
        authActions.signInHandler({
          token: userCredential.user.accessToken,
        })
      );
    } catch (err) {
      console.log(err.code);
      dispatch(errorActions.turnOffError());

      if (err.code === "auth/wrong-password") {
        const message = "Wrong password!";
        dispatch(errorActions.passwordErrorHandler(message));
      }
      if (err.code === "auth/user-not-found") {
        const message = "This account does not exist, please sign up!";
        dispatch(errorActions.emailErrorHandler(message));
      }
      dispatch(authActions.toggleLoading());
    }
  };
};

export const signInWithGoogle = () => {
  return async (dispatch) => {
    const provider = new GoogleAuthProvider();

    try {
      const result = await signInWithPopup(auth, provider);
      dispatch(errorActions.turnOffError());

      const credential = GoogleAuthProvider.credentialFromResult(result);

      console.log(credential);
      console.log(result);

      dispatch(
        authActions.signInHandler({
          token: result.user.accessToken,
        })
      );
    } catch (error) {
      const errorMessage = error.message;
      console.log(errorMessage);
    }
  };
};
