import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/cupertino.dart';
import 'package:UniClub/main/Screens/Clubs/components/club_card_info.dart';
import 'package:UniClub/main/Screens/Signup/signup_screen.dart';
import 'package:UniClub/model/member.dart';
import 'package:UniClub/model/user.dart';
import 'package:UniClub/network/member_request.dart';
import 'package:UniClub/network/user_request.dart';

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
    });
  }

  @override
  void dispose() {
    // TODO: implement dispose
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
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
