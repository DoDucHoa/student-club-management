import 'package:flutter/material.dart';
import 'package:flutter_auth/constants.dart';

class ClubCard extends StatelessWidget {
  final Widget pageRoute;
  final String logoUrl;
  final String Id;
  final String Name;

  const ClubCard(
      {Key? key,
      required this.pageRoute,
      required this.logoUrl,
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
        width: size.width * 0.8,
        height: 80.0,
        decoration: BoxDecoration(
          border: Border.all(
            color: kPrimaryColor,
          ),
          color: Colors.white,
          borderRadius: BorderRadius.circular(25.0),
        ),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.start,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            SizedBox(
              width: 18,
            ),
            Image.asset(logoUrl, height: 50, width: 50),
            Container(
                padding: EdgeInsets.fromLTRB(18, 18, 0, 18),
                child: Column(
                    mainAxisAlignment: MainAxisAlignment.spaceAround,
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Text(Id,
                          textAlign: TextAlign.right,
                          style: TextStyle(
                            color: kPrimaryColor,
                            fontSize: 18,
                            fontWeight: FontWeight.bold,
                          )),
                      Text(Name,
                          textAlign: TextAlign.left,
                          style: TextStyle(
                            fontSize: 11,
                            color: kPrimaryColor,
                          )),
                    ]))
          ],
        ),
      ),
    );
  }
}
