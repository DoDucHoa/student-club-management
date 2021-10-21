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
                padding: EdgeInsets.fromLTRB(18, 5, 0, 4),
                width: size.width,
                height: size.height * 0.08,
                decoration: BoxDecoration(
                    color: kPrimaryColor.withOpacity(0.7),
                    borderRadius: BorderRadius.only(
                        bottomRight: Radius.circular(25.0),
                        bottomLeft: Radius.circular(25.0)),
                    border: Border.all(color: Colors.transparent)),
                alignment: Alignment.bottomLeft,
                child: Column(
                    mainAxisAlignment: MainAxisAlignment.end,
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Container(
                        child: Text(Id,
                            textAlign: TextAlign.left,
                            style: TextStyle(
                                color: kSubColor,
                                fontSize: 18,
                                fontWeight: FontWeight.bold,
                                // backgroundColor: Colors.white,
                                decorationStyle: TextDecorationStyle.solid)),
                      ),
                      SizedBox(
                        height: 7,
                      ),
                      Text(Name,
                          textAlign: TextAlign.left,
                          style: TextStyle(
                            fontSize: 13,
                            color: kSubColor,
                            // backgroundColor: Colors.white
                          )),
                    ]))
          ],
        ),
      ),
    );
  }
}
