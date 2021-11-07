import 'package:UniClub/main/constants.dart';
import 'package:UniClub/main/screens/Events/components/event_calendar.dart';
import 'package:UniClub/main/screens/Events/components/event_detail.dart';
import 'package:UniClub/main/screens/Events/components/event_landing.dart';
import 'package:UniClub/model/club.dart';
import 'package:UniClub/network/club_request.dart';
import 'package:flutter/painting.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';

class ClubEvent extends StatefulWidget {
  final String? clubId;
  ClubEvent(this.clubId, {Key? key}) : super(key: key);
  @override
  _ClubEventState createState() => _ClubEventState();
}

class _ClubEventState extends State<ClubEvent> {
  List<EventInfos>? data;
  bool showCalendar = false;
  @override
  void initState() {
    // TODO: implement initState
    ClubRequest.fetchClubsById(widget.clubId).then((dataFromServer) {
      setState(() {
        data = dataFromServer.members?.first.eventInfos;
      });
    });
  }

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;
    return Padding(
        padding: EdgeInsets.fromLTRB(8, 5, 8, 5),
        child: Column(children: [
          Visibility(
            visible: showCalendar,
            child: Container(
              width: size.width * 0.7,
              height: size.height * 0.2,
              child: EventCalender(),
            ),
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              IconButton(
                  onPressed: () => setState(() {
                        !showCalendar
                            ? showCalendar = true
                            : showCalendar = false;
                      }),
                  icon:
                      Icon(Icons.calendar_today_outlined, color: kPrimaryColor))
            ],
          ),
          Flexible(
              child: ListView.separated(
            padding: EdgeInsets.fromLTRB(0, 20, 0, 20),
            itemCount: data?.length ?? 0,
            itemBuilder: (context, index) {
              return EventCard(
                  pageRoute: EventDetail(data?[index].id),
                  image: '${data?[index].image}',
                  Time: '${DateFormat("dd/MM/yyyy").format(data?[index].beginDate ?? DateTime.now())}' +
                      ' - ' +
                      '${DateFormat("dd/MM/yyyy").format(data?[index].dueDate ?? DateTime.now())}',
                  Id: '${data?[index].title}');
            },
            separatorBuilder: (BuildContext context, int index) =>
                const SizedBox(height: 10),
          ))
        ]));
  }
}
