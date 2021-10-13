import 'package:flutter/cupertino.dart';
import 'package:flutter_auth/main/Screens/Clubs/components/club_card_info.dart';
import 'package:flutter_auth/main/Screens/Signup/signup_screen.dart';
import 'package:flutter_auth/model/club.dart';
import 'package:flutter_auth/network/club_request.dart';
import 'package:flutter_auth/service/loadimg.dart';

class DiscoveryClub extends StatefulWidget {
  @override
  ListClubState createState() => ListClubState();
}

class ListClubState extends State<DiscoveryClub> {
  List<Club>? data;
  // }
  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    ClubRequest.fetchClubs().then((dataFromServer) {
      setState(() {
        data = dataFromServer;
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
    // TODO: implement build
    // NetworkRequest.fetchClubs().then((dataFromServer) {
    //   setState(() {
    //     data = dataFromServer;
    //   });
    // });
    return ListView.separated(
      padding: EdgeInsets.all(8),
      itemCount: data?.length ?? 0,
      itemBuilder: (context, index) {
        return ClubCard(
            pageRoute: SignUpScreen(),
            logoUrl: '${data?[index].logo}',
            Id: '${data?[index].id}',
            Name: '${data?[index].name}');
      },
      separatorBuilder: (BuildContext context, int index) =>
          const SizedBox(height: 10),
    );
  }
}
