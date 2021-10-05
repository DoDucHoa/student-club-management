import 'package:flutter/material.dart';
import 'package:flutter_auth/components/text_field_container.dart';
import 'package:flutter_auth/constants.dart';

class PasswordInput extends StatefulWidget {
  final ValueChanged<String> onChange;
  final String hintText;
  final TextInputAction inputAction;
  final TextEditingController controller;

  const PasswordInput(
      this.onChange, this.hintText, this.inputAction, this.controller);

  @override
  _PasswordInputState createState() => _PasswordInputState();
}

class _PasswordInputState extends State<PasswordInput> {
  bool isHidden = true;

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;
    return TextFieldContainer(
      child: TextFormField(
        controller: widget.controller,
        onChanged: widget.onChange,
        obscureText: isHidden,
        enableSuggestions: false,
        autocorrect: false,
        textInputAction: widget.inputAction,
        decoration: InputDecoration(
          icon: Icon(
            Icons.lock,
            color: kPrimaryColor,
          ),
          suffixIcon: IconButton(
              onPressed: togglePasswordVisibility,
              icon: isHidden
                  ? Icon(
                      Icons.visibility_off,
                      color: kPrimaryColor,
                    )
                  : Icon(
                      Icons.visibility,
                      color: kPrimaryColor,
                    )),
          border: InputBorder.none,
          hintText: widget.hintText,
        ),
        keyboardType: TextInputType.visiblePassword,
        validator: (passwordValue) {
          if (passwordValue != null && passwordValue.length < 5) {
            return 'Enter minimum 5 characters';
          }
          return null;
        },
      ),
    );
  }

  void togglePasswordVisibility() => setState(() => isHidden = !isHidden);
}
