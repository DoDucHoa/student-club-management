import 'package:UniClub/main/screens/Home/home.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/cupertino.dart';
import 'package:UniClub/main/screens/Welcome/welcome_screen.dart';

class Wrapper extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    // TODO: implement build
    final user = FirebaseAuth.instance.currentUser;
    print(user);
    if (user == null) {
      return WelcomeScreen();
    } else {
      return Home();
    }
  }
}
