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
  List<EventInfos>? incoming;
  List<EventInfos>? available;
  List<EventInfos>? joined;
  String? dropdownValue = "All Available Events";
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
        padding: EdgeInsets.fromLTRB(20, 5, 20, 5),
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
              DropdownButton<String>(
                value: dropdownValue,
                icon: const Icon(Icons.arrow_drop_down, color: kPrimaryColor),
                iconSize: 24,
                elevation: 16,
                style: const TextStyle(
                    fontSize: 20,
                    fontWeight: FontWeight.bold,
                    color: kPrimaryColor),
                onChanged: (String? newValue) {
                  setState(() {
                    dropdownValue = newValue!;
                  });
                },
                items: <String>[
                  'All Available Events',
                  'Incoming Events',
                  'Joined Events'
                ].map<DropdownMenuItem<String>>((String value) {
                  return DropdownMenuItem<String>(
                    value: value,
                    child: Text(value),
                  );
                }).toList(),
              ),
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
            padding: EdgeInsets.all(20),
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
