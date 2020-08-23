import 'package:MySyncroFlutterMobileApp/CustomWidget/ContactWidget.dart';
import 'package:MySyncroFlutterMobileApp/Models/SyncSessionModel.dart';
import 'package:MySyncroFlutterMobileApp/Services/ContactService.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';

class ContactListPage extends StatefulWidget 
{

  SyncSessionModel _currentSyncSession;

  ContactListPage(SyncSessionModel syncSessionModel){
    this._currentSyncSession = syncSessionModel;
    Intl.defaultLocale = 'fr_FR';
  }

  @override
  _ContactListPageState createState() => _ContactListPageState(_currentSyncSession);
}

class _ContactListPageState extends State<ContactListPage> {
  SyncSessionModel _currentModel = new SyncSessionModel();

  _ContactListPageState(syncSessionModel){
    _currentModel = syncSessionModel;
  }

  String formatDatefromDateTime(DateTime sourceDateTime)
  {
    return DateFormat.yMMMMEEEEd().format(sourceDateTime);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(

      appBar: AppBar(
         backgroundColor: Color.fromARGB(255, 111,0,255),
         title: Text('Liste de dcontacts', textAlign: TextAlign.center),
         leading: IconButton(icon: Icon(Icons.arrow_back_ios), onPressed: (){ Navigator.pop(context);},iconSize: 30.0,),
         actions: [
           IconButton(icon: Icon(Icons.search), onPressed: (){},iconSize: 30.0,)
         ],
       ),

      body: FutureBuilder(
        future: ContactService.getContactListBySessionId(_currentModel.id).then((value) => {_currentModel = value}),
        builder: (context, snapshot) {
          if(snapshot.hasData)
          {
            return Column
            (              
              children: 
              [
                /*Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    Text("Contacts Favoris", style: TextStyle(fontSize: 14, color: Color.fromARGB(255, 155, 126, 100), fontWeight: FontWeight.w900)),
                    Container(
                      height: 120.0,
                      color: Color.fromARGB(255, 111,0,255),
                      child: ListView.builder(itemBuilder: null),
                    )
                  ],
                ),*/
                RichText(
                  text: TextSpan(
                    style: DefaultTextStyle.of(context).style,
                    children: <TextSpan>[
                      TextSpan(text: "Synchronisation du "),
                      TextSpan(text: formatDatefromDateTime( _currentModel.creationDate), style: TextStyle(fontWeight: FontWeight.w500)),
                      TextSpan(text: ", avec "),
                      TextSpan(text: "${_currentModel.sessionItemsCount}", style: TextStyle(fontWeight: FontWeight.w500)),
                      TextSpan(text: " contacts enregistrés."),
                    ]
                  ),
                ),
                ListView.builder(
                  scrollDirection: Axis.vertical,
                  itemCount: _currentModel.syncedContactList.length,
                  itemBuilder: (context, index) {
                    return InkWell( 
                      child: ContactWidget(_currentModel.syncedContactList[index]),
                      onTap: ()=>{
                          Scaffold.of(context).showSnackBar(
                          SnackBar(
                            content: Text(_currentModel.syncedContactList[index].contactName),
                            backgroundColor: Colors.purple[200],
                            ))
                    });
                  })
                ],
            );
          }else if(snapshot.hasError) {           
            print(snapshot.error);
            return Center(child: Text('An error has occured !!!'));
          }else {
            return Center(child: CircularProgressIndicator());
          }
        }
      )
    );
  }
}