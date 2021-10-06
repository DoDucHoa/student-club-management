import 'package:flutter/material.dart';
import 'package:flutter_auth/Screens/Signup/signup_screen.dart';
import 'package:flutter_auth/Screens/Welcome/components/background.dart';
import 'package:flutter_auth/components/img_card_button.dart';
import 'package:flutter_auth/components/svg_card_button.dart';
import 'package:flutter_auth/constants.dart';
import 'package:google_fonts/google_fonts.dart';

class Body extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;
    // This size provide us total height and width of our screen
    return Background(
      child: SingleChildScrollView(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.start,
          children: <Widget>[
            Image.asset(
              "assets/images/UniClub-logo.png",
              height: size.height * 0.1,
              alignment: Alignment.center,
            ),
            Text(
              "Welcome, Hong!",
              textAlign: TextAlign.left,
              style: GoogleFonts.openSans(
                  fontSize: 20,
                  fontWeight: FontWeight.bold,
                  color: kPrimaryColor),
            ),
            Text(
              "Let's choose what you want.",
              textAlign: TextAlign.left,
              style: GoogleFonts.openSans(
                  fontSize: 15,
                  fontStyle: FontStyle.italic,
                  color: kPrimaryColor),
            ),
            SizedBox(height: size.height * 0.05),
            Container(
              child: Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  ImgCardButton(
                      pageRoute: SignUpScreen(),
                      imageUrl: "assets/images/fan_club.png",
                      buttonText: "Clubs"),
                  SizedBox(
                    width: size.width * 0.08,
                  ),
                  ImgCardButton(
                      pageRoute: SignUpScreen(),
                      imageUrl: "assets/images/planner.png",
                      buttonText: "Events")
                ],
              ),
            ),
            SizedBox(
              height: size.width * 0.08,
            ),
            Container(
              child: Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  ImgCardButton(
                      pageRoute: SignUpScreen(),
                      imageUrl: "assets/images/notification.png",
                      buttonText: "Notifications"),
                  SizedBox(
                    width: size.width * 0.08,
                  ),
                  ImgCardButton(
                      pageRoute: SignUpScreen(),
                      imageUrl: "assets/images/user.png",
                      buttonText: "Profile")
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}
