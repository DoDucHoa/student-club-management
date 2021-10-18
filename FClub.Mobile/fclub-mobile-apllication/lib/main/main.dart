import 'package:firebase_core/firebase_core.dart';
import 'package:flutter/material.dart';
import 'package:UniClub/main/Screens/Welcome/welcome_screen.dart';
import 'package:UniClub/main/constants.dart';
import 'package:UniClub/main/home.dart';
import 'package:UniClub/main/screens/Authenticate/wrapper.dart';
import 'package:UniClub/service/auth.dart';
import 'package:provider/provider.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await Firebase.initializeApp();
  runApp(MyApp());
}

class MyApp extends StatefulWidget {
  _AppState createState() => _AppState();
}

class _AppState extends State<MyApp> {
  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    // if (_error) {
    //   print("Something went wrong");
    // }
    // if (!_initialized) {
    //   print("Loading");
    // }
    return StreamProvider.value(
        value: AuthService().user,
        initialData: null,
        child: MaterialApp(
          debugShowCheckedModeBanner: false,
          title: 'Flutter Auth',
          theme: ThemeData(
            primaryColor: kPrimaryColor,
            scaffoldBackgroundColor: Colors.white,
          ),
          home: Wrapper(),
        ));
  }

  // bool _initialized = false;
  // bool _error = false;

  // // Define an async function to initialize FlutterFire
  // void initializeFlutterFire() async {
  //   try {
  //     // Wait for Firebase to initialize and set `_initialized` state to true
  //     await Firebase.initializeApp();
  //     setState(() {
  //       _initialized = true;
  //     });
  //   } catch (e) {
  //     // Set `_error` state to true if Firebase initialization fails
  //     setState(() {
  //       _error = true;
  //     });
  //   }
  // }

  @override
  void initState() {
    super.initState();
  }
}
