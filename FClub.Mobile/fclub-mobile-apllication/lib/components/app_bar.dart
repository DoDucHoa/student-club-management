import 'package:flutter/material.dart';
import 'package:flutter_auth/components/rounded_button.dart';
import 'package:flutter_auth/constants.dart';
import 'package:google_fonts/google_fonts.dart';

class TitleBar extends StatelessWidget with PreferredSizeWidget {
  @override
  Size get preferredSize {
    return new Size.fromHeight(50.0);
  }

  final String title;

  const TitleBar(
    this.title, {
    Key? key,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.start,
      children: [
        IconButton(
          onPressed: () => Navigator.pop(context),
          icon: Icon(Icons.arrow_back_ios_new),
          color: kPrimaryColor,
        ),
        SizedBox(width: 115.0),
        Container(
            alignment: Alignment.center,
            child:
                Column(mainAxisAlignment: MainAxisAlignment.center, children: [
              Image.asset(
                "assets/images/UniClub-logo.png",
                height: 25.0,
              ),
              Text(
                title,
                style: GoogleFonts.dmSans(
                    fontWeight: FontWeight.bold,
                    color: kPrimaryColor,
                    fontSize: 20.0,
                    letterSpacing: 2.0),
              ),
            ])),
      ],
    );
  }
}
