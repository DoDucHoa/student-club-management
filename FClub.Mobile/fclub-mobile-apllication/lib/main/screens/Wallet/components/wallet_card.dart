import 'package:UniClub/main/components/rounded_button.dart';
import 'package:flutter/material.dart';
import 'package:UniClub/main/constants.dart';

class WalletCard extends StatelessWidget {
  final String clubname;
  final double balance;
  final String logo;

  const WalletCard(
      {Key? key,
      required this.clubname,
      required this.balance,
      required this.logo})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;
    return InkWell(
      child: Container(
        width: size.width,
        height: size.height * 0.3,
        decoration: BoxDecoration(
          border: Border.all(
            color: kPrimaryColor,
          ),
          color: kPrimaryColor,
          borderRadius: BorderRadius.circular(15.0),
        ),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceAround,
          children: [
            Container(
                width: size.width * 0.5,
                height: size.height * 0.15,
                decoration: BoxDecoration(
                    shape: BoxShape.circle,
                    border: Border.all(
                      color: kPrimaryColor,
                    ),
                    color: kPrimaryColor,
                    image: new DecorationImage(
                      image: NetworkImage(logo),
                      fit: BoxFit.fitHeight,
                    ))),
          ],
        ),
      ),
    );
  }
}
