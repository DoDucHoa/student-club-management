import 'package:UniClub/main/screens/Clubs/components/club_detail.dart';
import 'package:flutter/cupertino.dart';
import 'package:UniClub/main/Screens/Clubs/components/club_card_info.dart';
import 'package:UniClub/main/Screens/Signup/signup_screen.dart';
import 'package:UniClub/model/club.dart';
import 'package:UniClub/network/club_request.dart';

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
    return ListView.separated(
      padding: EdgeInsets.all(8),
      itemCount: data?.length ?? 0,
      itemBuilder: (context, index) {
        return ClubCard(
            pageRoute: ClubDetail(data?[index].id, false),
            logoUrl: '${data?[index].logo}',
            Id: '${data?[index].id}',
            Name: '${data?[index].name}');
      },
      separatorBuilder: (BuildContext context, int index) =>
          const SizedBox(height: 10),
    );
  }
}
