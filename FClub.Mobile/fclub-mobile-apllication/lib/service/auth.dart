import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter_auth/model/token.dart';
import 'package:flutter_auth/model/user.dart';
import 'package:flutter_auth/network/auth_request.dart';
import 'package:google_sign_in/google_sign_in.dart';

class AuthService {
  final FirebaseAuth _auth = FirebaseAuth.instance;
  final GoogleSignIn _googleSignIn = GoogleSignIn();
  final AuthRequest _request = AuthRequest();

  Student? _userFromFirebaseUser(User? user) {
    return user != null ? Student(data: [Data(email: user.email)]) : null;
  }

  //auth changer user stream
  Stream<User>? get user {
    _auth.userChanges().map(_userFromFirebaseUser);
  }

  //sign in google
  Future signInWithGoogle() async {
    try {
      final GoogleSignInAccount? googleUser = await _googleSignIn.signIn();
      final GoogleSignInAuthentication googleAuth =
          await googleUser!.authentication;

      final AuthCredential credential = GoogleAuthProvider.credential(
        accessToken: googleAuth.accessToken,
        idToken: googleAuth.idToken,
      );

      User? user = (await _auth.signInWithCredential(credential)).user;
      print(await user?.getIdToken());
      _request.signIn(await user?.getIdToken());
      return _userFromFirebaseUser(user);
    } catch (e) {
      print(e.toString());
      return null;
    }
  }

  //sign in with email - password
  Future signInWithEmail(String email, String password) async {
    try {
      UserCredential result = await _auth.signInWithEmailAndPassword(
          email: email, password: password);
      User? user = result.user;
      return _userFromFirebaseUser(user);
    } catch (e) {
      print(e.toString());
      return null;
    }
  }

  //register with email - password

  //sign out
  Future signOut() async {
    try {
      return await _auth.signOut();
    } catch (e) {
      print(e.toString());
      return null;
    }
  }
}
