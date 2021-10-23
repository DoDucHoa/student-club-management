import 'package:UniClub/main/constants.dart';
import 'package:UniClub/main/screens/Events/components/event_calendar.dart';
import 'package:flutter/painting.dart';

import '';
import 'package:UniClub/main/screens/Signup/signup_screen.dart';
import 'package:UniClub/model/event.dart';
import 'package:UniClub/network/event_request.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';

import 'components/event_landing.dart';

class EventScreen extends StatefulWidget {
  @override
  _EventState createState() => _EventState();
}

class _EventState extends State<EventScreen> {
  List<Data>? data;
  String? dropdownValue = "All Available Events";
  bool showCalendar = false;
  @override
  void initState() {
    // TODO: implement initState
    EventRequest.fetchAvailableEvents().then((dataFromServer) {
      setState(() {
        data = dataFromServer.data!.toList();
      });
    });
  }

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;
    return Center(
        child: Column(children: [
      Visibility(
        visible: showCalendar,
        child: Container(
          width: size.width * 0.8,
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
                    !showCalendar ? showCalendar = true : showCalendar = false;
                  }),
              icon: Icon(Icons.calendar_today_outlined, color: kPrimaryColor))
        ],
      ),
      Expanded(
          child: ListView.separated(
        padding: EdgeInsets.all(8),
        itemCount: data?.length ?? 0,
        itemBuilder: (context, index) {
          return EventCard(
              pageRoute: SignUpScreen(),
              image: '${data?[index].image}',
              Name: '${DateFormat("dd/MM/yyyy").format(data?[index].beginDate ?? DateTime.now())}' +
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
