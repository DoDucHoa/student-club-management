import 'package:UniClub/main/components/outlined_text.dart';
import 'package:UniClub/main/components/rounded_button.dart';
import 'package:UniClub/main/constants.dart';
import 'package:UniClub/main/screens/Welcome/welcome_screen.dart';
import 'package:UniClub/model/user.dart';
import 'package:UniClub/network/user_request.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:google_sign_in/google_sign_in.dart';
import 'package:intl/intl.dart';

class ProfileScreen extends StatefulWidget {
  @override
  ProfileState createState() => ProfileState();
}

class ProfileState extends State<ProfileScreen> {
  FirebaseAuth _auth = FirebaseAuth.instance;
  Student? user;
  bool _status = false;
  DateTime selectedDate = DateTime.now();
  TextEditingController name = new TextEditingController();
  TextEditingController phone = new TextEditingController();
  TextEditingController birth = new TextEditingController();

  void _selectDate(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
      context: context,
      initialDate: selectedDate,
      firstDate: DateTime(1965),
      lastDate: DateTime(2025),
    );
    if (picked != null && picked != selectedDate)
      setState(() {
        selectedDate = picked;
        birth.text = DateFormat('dd?MM/yyyy').format(selectedDate);
      });
  }

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
        birth.text = DateFormat('dd/MM/yyyy')
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
            GestureDetector(
              onTap: !_status ? null : () => _selectDate(context),
              child: OutlinedText(
                  controller: birth,
                  labelText: "Birthday",
                  icon: Icons.calendar_today_rounded,
                  enable: false),
            ),
            SizedBox(
              height: size.height * 0.015,
            ),
            !_status ? _getEditIcon() : _getActionButtons()
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
            color: kSubColor,
            textColor: kPrimaryColor,
            width: size.width * 0.3,
            text: "Cancel",
            press: () {
              setState(() {
                _status = false;
              });
            },
          ),
          RoundedButton(
            width: size.width * 0.3,
            text: "Save",
            press: () {
              setState(() {
                _status = false;
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
