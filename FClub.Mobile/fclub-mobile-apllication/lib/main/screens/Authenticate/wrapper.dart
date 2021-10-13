import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_auth/main/Screens/Starter/starter_screen.dart';
import 'package:flutter_auth/main/screens/Signin/login_screen.dart';
import 'package:flutter_auth/main/screens/Welcome/welcome_screen.dart';
import 'package:provider/provider.dart';

class Wrapper extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    // TODO: implement build
    final user = FirebaseAuth.instance.currentUser;
    print(user);
    if (user == null) {
      return WelcomeScreen();
    } else {
      return StarterScreen();
    }
  }
}
