import 'package:MySyncroFlutterMobileApp/Models/ContactModel.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class ContactWidget extends StatelessWidget {

  ContactModel _currentContact;

  ContactWidget(ContactModel contactModel)
  {
    _currentContact = contactModel;
  }

  @override
   Widget build(BuildContext context) {

     return Card(
       color: Colors.blueGrey,
       child: ListTile(
         leading: Icon( Icons.person),
         title: Text(_currentContact.contactName) ,
         subtitle: Text(_currentContact.contactPhoneNumber),
         isThreeLine: true,
         dense: true,
         trailing: Icon(Icons.arrow_forward),
         onTap: () {Scaffold.of(context).showSnackBar(
           SnackBar(
             content: Text(_currentContact.contactName),
             backgroundColor: Colors.purple[700]
             ));
           }
     ),
       );     
   }

}