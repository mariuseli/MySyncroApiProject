import 'package:MySyncroFlutterMobileApp/Models/ContactModel.dart';
import 'package:flutter/material.dart';

class CustomContactAvatar extends StatefulWidget {
  
  ContactModel _workingContactModel;

  CustomContactAvatar(ContactModel currentContact){_workingContactModel =currentContact; }

  @override
  _CustomContactAvatarState createState() => _CustomContactAvatarState(_workingContactModel);
}

class _CustomContactAvatarState extends State<CustomContactAvatar> {

  ContactModel _workingContactModel;
  _CustomContactAvatarState(ContactModel currentContact){_workingContactModel = currentContact; }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [ 
        CircleAvatar(
          radius: 35.0,
          backgroundImage: AssetImage("lib/images/account_circle-24px.svg"),
        ),
        SizedBox(height: 6.0),
        Text(
          _workingContactModel.contactName,
          style: TextStyle(color: Colors.blueGrey, fontWeight: FontWeight.w500),
        )
      ]
        
      );
  }
}