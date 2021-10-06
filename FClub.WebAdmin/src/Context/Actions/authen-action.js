import { authActions } from "../Slicer/AuthSlicer";
import { errorActions } from "../Slicer/ErrorSlicer";

// firebase
import { auth } from "../../Constants/Firebase";
import {
  createUserWithEmailAndPassword,
  signInWithEmailAndPassword,
  GoogleAuthProvider,
  signInWithPopup,
  signOut,
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
      dispatch(authActions.toggleLoading());
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

      console.log(result.user.accessToken);

      //const credential = GoogleAuthProvider.credentialFromResult(result);
      const backendResponse = await getTokenFromBackend(
        result.user.accessToken
      );

      dispatch(
        authActions.signInHandler({
          token: backendResponse.jwtToken,
        })
      );
      console.log(backendResponse.jwtToken);
    } catch (error) {
      const errorMessage = error.message;
      console.log(errorMessage);
    }
  };
};

export const signOutWeb = () => {
  return async (dispatch) => {
    try {
      const response = await signOut(auth);
      console.log(response);
      dispatch(authActions.signOutHandler());
    } catch (error) {
      console.log(error);
    }
  };
};

const getTokenFromBackend = async (firebaseToken) => {
  try {
    const response = await fetch(
      "https://club-management-service.azurewebsites.net/api/auths/sign-in?IdToken=" +
        firebaseToken,
      {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
      }
    );
    return response.json();
  } catch (error) {
    console.log(error);
  }
};
