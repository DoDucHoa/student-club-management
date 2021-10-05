import * as firebase from "firebase/app";
import { getAuth } from "firebase/auth";

const firebaseConfig = {
  apiKey: "AIzaSyBqDw1-2F_ycVi-Y6VTztrfekcl3WBbs9I",
  authDomain: "auth-club-management-dev.firebaseapp.com",
  databaseURL:
    "https://auth-club-management-dev-default-rtdb.asia-southeast1.firebasedatabase.app",
  projectId: "auth-club-management-dev",
  storageBucket: "auth-club-management-dev.appspot.com",
  messagingSenderId: "200059558387",
  appId: "1:200059558387:web:9ca9d25db8839b96531a86",
};

// var firebaseConfig = {
//   apiKey: process.env.REACT_API_FIREBASE_KEY,
//   authDomain: process.env.REACT_APP_FIREBASE_AUTH_DOMAIN,
//   projectId: process.env.REACT_APP_FIREBASE_PROJECT_ID,
//   storageBucket: process.env.REACT_APP_FIREBASE_STORAGE_BUCKET,
//   messagingSenderId: process.env.REACT_APP_FIREBASE_MESSAGING_SENDER_ID,
//   appId: process.env.REACT_APP_FIREBASE_APP_ID,
// };

firebase.initializeApp(firebaseConfig);

export const auth = getAuth();

export default firebase;
