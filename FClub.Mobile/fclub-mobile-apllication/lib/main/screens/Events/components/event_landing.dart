import 'package:UniClub/main/components/rounded_button.dart';
import 'package:flutter/material.dart';
import 'package:UniClub/main/constants.dart';

class EventCard extends StatelessWidget {
  final Widget pageRoute;
  final String image;
  final String Id;
  final String Name;

  const EventCard(
      {Key? key,
      required this.pageRoute,
      required this.image,
      required this.Id,
      required this.Name})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;
    return InkWell(
      onTap: () => Navigator.push(
          context, MaterialPageRoute(builder: (context) => pageRoute)),
      child: Container(
        width: size.width,
        height: size.height * 0.2,
        decoration: BoxDecoration(
            border: Border.all(
              color: Colors.transparent,
            ),
            color: Colors.white,
            borderRadius: BorderRadius.circular(25.0),
            image: DecorationImage(
                image: NetworkImage(image), fit: BoxFit.fitWidth)),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.end,
          children: [
            Container(
                padding: EdgeInsets.fromLTRB(18, 5, 18, 10),
                width: size.width,
                height: size.height * 0.08,
                decoration: BoxDecoration(
                    color: kPrimaryColor.withOpacity(0.7),
                    borderRadius: BorderRadius.only(
                        bottomRight: Radius.circular(25.0),
                        bottomLeft: Radius.circular(25.0)),
                    border: Border.all(color: Colors.transparent)),
                alignment: Alignment.bottomLeft,
                child: Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Container(
                          child: Column(
                              mainAxisAlignment: MainAxisAlignment.end,
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                            Text(Id,
                                textAlign: TextAlign.left,
                                style: TextStyle(
                                    color: kSubColor,
                                    fontSize: 18,
                                    fontWeight: FontWeight.bold,
                                    decorationStyle:
                                        TextDecorationStyle.solid)),
                            SizedBox(
                              height: 7,
                            ),
                            Text(Name,
                                textAlign: TextAlign.left,
                                style: TextStyle(
                                  fontSize: 13,
                                  color: kSubColor,
                                )),
                          ])),
                      Container(
                          child: Row(children: [
                        Text("See details",
                            textAlign: TextAlign.right,
                            style: TextStyle(
                              fontSize: 20,
                              color: kSubColor,
                              fontWeight: FontWeight.bold,
                            )),
                        IconButton(
                            iconSize: 25,
                            onPressed: () {},
                            icon: Icon(
                              Icons.arrow_right_outlined,
                              color: kSubColor,
                              size: 20,
                            )),
                      ]))
                      // RoundedButton(
                      //     text: 'Die',
                      //     press: () {},
                      //     color: kSubColor,
                      //     textColor: kPrimaryColor)
                    ])),
          ],
        ),
      ),
    );
  }
}
