import 'package:UniClub/main/components/outlined_text.dart';
import 'package:UniClub/main/components/rounded_button.dart';
import 'package:UniClub/main/constants.dart';
import 'package:UniClub/model/user.dart';
import 'package:UniClub/network/user_request.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:intl/intl.dart';

class ProfileScreen extends StatefulWidget {
  @override
  ProfileState createState() => ProfileState();
}

class ProfileState extends State<ProfileScreen> {
  Student? user;
  bool _status = false;
  TextEditingController name = new TextEditingController();
  TextEditingController phone = new TextEditingController();
  TextEditingController birth = new TextEditingController();
  @override
  void initState() {
    // TODO: implement initState

    super.initState();
    UserRequest.fetchUserByEmail(FirebaseAuth.instance.currentUser!.email)!
        .then((dataFromServer) {
      setState(() {
        user = dataFromServer;
        name.text = user?.data?.first.name ?? "null";
        phone.text = user?.data?.first.phone ?? "null";
        birth.text = DateFormat('yyyy-MM-dd')
            .format(user?.data?.first.birthday ?? DateTime.now());
      });
    });
  }

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;
    return Scaffold(
        // resizeToAvoidBottomInset: false,
        body: SingleChildScrollView(
      child: Center(
        child: IntrinsicHeight(
            child: Column(
          mainAxisSize: MainAxisSize.max,
          children: [
            Container(
              height: size.height * 0.2,
              decoration: BoxDecoration(
                  border: Border.all(
                      color: kPrimaryColor,
                      width: 5.0,
                      style: BorderStyle.solid),
                  shape: BoxShape.circle,
                  image: new DecorationImage(
                      image: NetworkImage(user?.data?.first.photo ?? "null"),
                      fit: BoxFit.fitHeight)),
            ),
            SizedBox(height: size.height * 0.05),
            Text(
              'Personal Information',
              style: GoogleFonts.poppins(
                  fontSize: 20.0,
                  fontWeight: FontWeight.bold,
                  color: kPrimaryColor),
            ),
            OutlinedText(
                controller: name,
                labelText: "Name",
                icon: Icons.account_circle_rounded,
                enable: _status),
            OutlinedText(
                controller: phone,
                labelText: "Phone Number",
                icon: Icons.phone,
                enable: _status),
            OutlinedText(
                controller: birth,
                labelText: "Birthday",
                icon: Icons.calendar_today_rounded,
                enable: _status),
            SizedBox(
              height: size.height * 0.015,
            ),
            !_status ? _getEditIcon() : _getActionButtons(),
          ],
        )),
      ),
    ));
  }

  Widget _getActionButtons() {
    Size size = MediaQuery.of(context).size;
    return Container(
      child: new Row(
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        children: <Widget>[
          RoundedButton(
            width: size.width * 0.3,
            text: "Save",
            press: () {
              setState(() {
                _status = true;
                FocusScope.of(context).requestFocus(new FocusNode());
              });
            },
          ),
          RoundedButton(
            color: kSubColor,
            textColor: kPrimaryColor,
            width: size.width * 0.3,
            text: "Cancel",
            press: () {
              setState(() {
                _status = false;
                FocusScope.of(context).requestFocus(new FocusNode());
              });
            },
          ),
        ],
      ),
    );
  }

  Widget _getEditIcon() {
    return new GestureDetector(
      child: new CircleAvatar(
        backgroundColor: kPrimaryColor,
        radius: 30,
        child: new Icon(
          Icons.edit,
          color: Colors.white,
          size: 32.0,
        ),
      ),
      onTap: () {
        setState(() {
          _status = true;
        });
      },
    );
  }
}
