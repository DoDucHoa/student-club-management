import 'package:UniClub/main/screens/Clubs/components/club_home.dart';
import 'package:UniClub/model/approve.dart';
import 'package:UniClub/network/club_request.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/cupertino.dart';
import 'package:UniClub/main/Screens/Clubs/components/club_card_info.dart';
import 'package:UniClub/model/user.dart';
import 'package:UniClub/network/user_request.dart';

class YourClub extends StatefulWidget {
  @override
  ListClubState createState() => ListClubState();
}

class ListClubState extends State<YourClub> {
  Student? user;
  List<Approve>? clubs;
  List<Approve>? data;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    UserRequest.fetchUserByEmail(FirebaseAuth.instance.currentUser!.email)!
        .then((dataFromServer) {
      setState(() {
        user = dataFromServer;
      });
      ClubRequest.fetchClubsWithApprove(user?.data?.first.id)
          .then((dataFromServer) {
        setState(() {
          clubs = dataFromServer;
          data = clubs
              ?.where((element) =>
                  element.value!.startsWith("W") ||
                  element.value!.startsWith("J"))
              .toList();
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
      itemCount: data?.length ?? 0,
      itemBuilder: (context, index) {
        return ClubCard(
            isJoined: data?[index].value == "Waitting" ? false : true,
            Status: data?[index].value ?? "",
            pageRoute: ClubHome(data?[index].key?.id),
            logoUrl: data?[index].key?.logo ?? "",
            Id: data?[index].key?.id ?? "",
            Name: data?[index].key?.name ?? "");
      },
      separatorBuilder: (BuildContext context, int index) =>
          const SizedBox(height: 10),
    );
  }
}
