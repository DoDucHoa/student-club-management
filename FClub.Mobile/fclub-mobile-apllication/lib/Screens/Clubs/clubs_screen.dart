import 'package:flutter/material.dart';
import 'package:flutter_auth/Screens/Clubs/components/club_card_info.dart';
import 'package:flutter_auth/Screens/Signup/signup_screen.dart';
import 'package:flutter_auth/components/app_bar.dart';
import 'package:flutter_auth/constants.dart';

class ClubOver extends StatefulWidget {
  @override
  ClubScreen createState() => ClubScreen();
}

class ClubScreen extends State<ClubOver> with SingleTickerProviderStateMixin {
  // ignore: unused_field
  TabController? controller;
  @override
  void initState() {
    // TODO: implement initState
    controller = TabController(length: 2, vsync: this);
    super.initState();
  }

  @override
  void dispose() {
    // TODO: implement dispose
    controller!.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: TitleBar("Club"),
      body: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 60, vertical: 10),
        child: Column(
          children: [
            // give the tab bar a height [can change hheight to preferred height]
            Container(
              height: 45,
              decoration: BoxDecoration(
                color: kSubColor,
                borderRadius: BorderRadius.circular(
                  25.0,
                ),
              ),
              child: TabBar(
                controller: controller,
                // give the indicator a decoration (color and border radius)
                indicator: BoxDecoration(
                  borderRadius: BorderRadius.circular(
                    25.0,
                  ),
                  color: kPrimaryColor,
                ),
                labelColor: Colors.white,
                unselectedLabelColor: kPrimaryColor,
                tabs: [
                  // first tab [you can add an icon using the icon property]
                  Tab(
                    text: 'Discovery',
                  ),

                  // second tab [you can add an icon using the icon property]
                  Tab(
                    text: 'Your Clubs',
                  ),
                ],
              ),
            ),
            SizedBox(height: 20),
            // tab bar view here
            Expanded(
              child: TabBarView(
                controller: controller,
                children: [
                  // first tab bar view widget

                  Container(
                      child: SingleChildScrollView(
                          child: Column(
                    mainAxisAlignment: MainAxisAlignment.start,
                    children: [
                      ClubCard(
                          pageRoute: SignUpScreen(),
                          logoUrl: "assets/images/UniClub.png",
                          Id: 'UNI',
                          Name: 'Câu lạc bộ các trường đại học UniClub')
                    ],
                  ))),

                  // second tab bar view widget
                  Center(
                    child: Text(
                      'Buy Now',
                      style: TextStyle(
                        fontSize: 25,
                        fontWeight: FontWeight.w600,
                      ),
                    ),
                  ),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}
