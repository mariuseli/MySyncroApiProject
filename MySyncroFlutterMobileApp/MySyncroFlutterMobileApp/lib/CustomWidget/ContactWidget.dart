import 'package:MySyncroFlutterMobileApp/Models/ContactModel.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class ContactWidget extends StatefulWidget {

  ContactModel _currentContact;

  ContactWidget(ContactModel contactModel)
  {
    _currentContact = contactModel;
  }

  @override
  _ContactWidgetState createState() => _ContactWidgetState();
}

class _ContactWidgetState extends State<ContactWidget> {
  @override
   Widget build(BuildContext context) {

     return Card(
       color: Colors.blueGrey,
       child: ListTile(
         leading: Icon( Icons.person),
         title: Text(widget._currentContact.contactName) ,
         subtitle: Text(widget._currentContact.contactPhoneNumber),
         isThreeLine: true,
         dense: true,
         trailing: Icon(Icons.arrow_forward),
         onTap: () {Scaffold.of(context).showSnackBar(
           SnackBar(
             content: Text(widget._currentContact.contactName),
             backgroundColor: Colors.purple[700]
             ));
           }
     ),
       );     
   }
}