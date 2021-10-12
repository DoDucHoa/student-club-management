import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_auth/main/Screens/Clubs/components/club_card_info.dart';
import 'package:flutter_auth/main/Screens/Signup/signup_screen.dart';
import 'package:flutter_auth/model/member.dart';
import 'package:flutter_auth/model/user.dart';
import 'package:flutter_auth/network/club_request.dart';
import 'package:flutter_auth/network/member_request.dart';
import 'package:flutter_auth/network/user_request.dart';

class YourClub extends StatefulWidget {
  @override
  ListClubState createState() => ListClubState();
}

class ListClubState extends State<YourClub> {
  Student? user;
  Member? data;
  // }
  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    UserRequest.fetchUserByEmail(FirebaseAuth.instance.currentUser!.email)!
        .then((dataFromServer) {
      setState(() {
        user = dataFromServer;
      });
      MemberRequest.fetchMembersById(user?.data?.first.id)!
          .then((dataFromServer) {
        setState(() {
          data = dataFromServer;
        });
      });
      // ClubRequest.fetchClubs().then((dataFromServer) {
      //   setState(() {
      //     data = dataFromServer;
      //   });
      // });
    });
  }

  @override
  void dispose() {
    // TODO: implement dispose
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    // TODO: implement build
    // NetworkRequest.fetchClubs().then((dataFromServer) {
    //   setState(() {
    //     data = dataFromServer;
    //   });
    // });
    return ListView.separated(
      padding: EdgeInsets.all(8),
      itemCount: data?.data?.length ?? 0,
      itemBuilder: (context, index) {
        return ClubCard(
            pageRoute: SignUpScreen(),
            logoUrl: '${data?.data?[index].club?.logo}',
            Id: '${data?.data?[index].club?.id}',
            Name: '${data?.data?[index].club?.name}');
      },
      separatorBuilder: (BuildContext context, int index) =>
          const SizedBox(height: 10),
    );
  }
}
