import 'package:UniClub/main/components/rounded_button.dart';
import 'package:UniClub/main/components/sub_appbar.dart';
import 'package:UniClub/main/constants.dart';
import 'package:UniClub/main/screens/Clubs/components/club_home.dart';
import 'package:UniClub/model/club.dart';
import 'package:UniClub/network/club_request.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';

class ClubDetail extends StatefulWidget {
  final String? clubId;
  bool joined;
  ClubDetail(this.clubId, this.joined, {Key? key}) : super(key: key);
  @override
  _ClubDetailState createState() => _ClubDetailState();
}

class _ClubDetailState extends State<ClubDetail> {
  Club? clubInfo;
  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    ClubRequest.fetchClubsById(widget.clubId).then((datafromserver) {
      setState(() {
        clubInfo = datafromserver;
      });
    });
  }

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;
    return Scaffold(
      appBar: SubBar("Club Detail"),
      body: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            Center(
              child: Container(
                width: size.width * 0.9,
                height: size.height * 0.34,
                decoration: BoxDecoration(
                    border: Border.all(
                      color: Colors.transparent,
                    ),
                    color: Colors.white,
                    borderRadius: BorderRadius.circular(15.0)),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.end,
                  children: [
                    Container(
                      padding: EdgeInsets.fromLTRB(18, 0, 18, 10),
                      height: size.height * 0.3,
                      decoration: BoxDecoration(
                          shape: BoxShape.circle,
                          image: new DecorationImage(
                              image: NetworkImage(clubInfo?.logo ?? ""),
                              fit: BoxFit.fitHeight)),
                    ),
                  ],
                ),
              ),
            ),
            Container(
                padding: EdgeInsets.fromLTRB(30, 0, 30, 0),
                child: Column(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    children: [
                      SizedBox(
                        height: 15.0,
                      ),
                      Text(clubInfo?.id ?? "",
                          textAlign: TextAlign.center,
                          style: TextStyle(
                              color: kPrimaryColor,
                              fontSize: 30,
                              fontWeight: FontWeight.bold,
                              decorationStyle: TextDecorationStyle.solid)),
                      SizedBox(
                        height: 15.0,
                      ),
                      Container(
                          child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                            Text.rich(
                              TextSpan(
                                  text: "Name: ",
                                  style: TextStyle(
                                      color: kPrimaryColor,
                                      fontSize: 20,
                                      fontWeight: FontWeight.bold,
                                      decorationStyle:
                                          TextDecorationStyle.solid),
                                  children: <TextSpan>[
                                    TextSpan(
                                      text: clubInfo?.name ?? "",
                                      style: TextStyle(
                                          color: Colors.black87,
                                          fontSize: 20,
                                          fontWeight: FontWeight.w400,
                                          decorationStyle:
                                              TextDecorationStyle.solid),
                                    )
                                  ]),
                            ),
                            Text.rich(
                              TextSpan(
                                  text: "About: ",
                                  style: TextStyle(
                                      color: kPrimaryColor,
                                      fontSize: 20,
                                      fontWeight: FontWeight.bold,
                                      decorationStyle:
                                          TextDecorationStyle.solid),
                                  children: <TextSpan>[
                                    TextSpan(
                                      text: clubInfo?.about ?? "",
                                      style: TextStyle(
                                          color: Colors.black87,
                                          fontSize: 20,
                                          fontWeight: FontWeight.w400,
                                          decorationStyle:
                                              TextDecorationStyle.solid),
                                    )
                                  ]),
                            ),
                            SizedBox(
                              height: 15.0,
                            ),
                          ])),
                      RoundedButton(
                        text: widget.joined == false
                            ? "Request to join"
                            : "Requested",
                        press: () {
                          setState(() {
                            if (widget.joined == false) widget.joined = true;
                          });
                        },
                        color: kPrimaryColor,
                        textColor: Colors.white,
                      )
                    ]))
          ],
        ),
      ),
    );
  }
}