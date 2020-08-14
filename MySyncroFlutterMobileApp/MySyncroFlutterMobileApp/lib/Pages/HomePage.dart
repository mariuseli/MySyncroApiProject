
import 'package:MySyncroFlutterMobileApp/CustomWidget/ContactWidget.dart';
import 'package:MySyncroFlutterMobileApp/Models/ContactModel.dart';
import 'package:MySyncroFlutterMobileApp/Services/ContactService.dart';
import 'package:flutter/material.dart';

class HomePage extends StatelessWidget {

  List<ContactModel> _contacts ;
 

   @override
   Widget build(BuildContext context) {    

     return Scaffold(
       appBar: AppBar(
         backgroundColor: Color.fromARGB(255, 111,0,255),
         title: const Text('Historique'),
       ),

      bottomNavigationBar: BottomAppBar(
        child: Row(
          children: [
            IconButton(icon: Icon(Icons.menu), onPressed: () {}),
            Spacer(),
            IconButton(icon: Icon(Icons.search), onPressed: () {}),
            IconButton(icon: Icon(Icons.more_vert), onPressed: () {}),
          ],
        ),
      ),

      floatingActionButton: FloatingActionButton(child: Icon(Icons.add), onPressed: () {}),
      floatingActionButtonLocation: FloatingActionButtonLocation.centerDocked,

      body: FutureBuilder(
        future: ContactService.getContactList().then((value) => {_contacts = value}),
        builder: (context, snapshot) {
          if(snapshot.hasData)
          {
            return ListView.builder(
              scrollDirection: Axis.vertical,
              itemCount: _contacts.length,
              itemBuilder: (context, index) {
                return ContactWidget(_contacts[index]);
              });
          }else if(snapshot.hasError) {
            Scaffold.of(context).showSnackBar(
              SnackBar(
                content: Text('Yay! A SnackBar!'),
                backgroundColor: Colors.purple[200],
                )
            );
            return null;
          }else {
            return CircularProgressIndicator();
          }
        }
      )
            
     );
   }
 }