import 'package:MySyncroFlutterMobileApp/CustomWidget/SyncSessionWidget.dart';
import 'package:MySyncroFlutterMobileApp/Models/SyncSessionModel.dart';
import 'package:MySyncroFlutterMobileApp/Services/ContactService.dart';
import 'package:flutter/material.dart';

class HomePage extends StatelessWidget {

  List<SyncSessionModel> _syncSessions ;
 
   @override
   Widget build(BuildContext context) {    

     return Scaffold(
       appBar: AppBar(
         backgroundColor: Color.fromARGB(255, 111,0,255),
         title: Text('Historique', textAlign: TextAlign.center),
         leading: IconButton(icon: Icon(Icons.menu), onPressed: (){},iconSize: 30.0,),
         actions: [
           IconButton(icon: Icon(Icons.search), onPressed: (){},iconSize: 30.0,)
         ],
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
        future: ContactService.getSyncSessions().then((value) => {_syncSessions = value}),
        builder: (context, snapshot) {
          if(snapshot.hasData)
          {
            return ListView.builder(
              scrollDirection: Axis.vertical,
              itemCount: _syncSessions.length,
              itemBuilder: (context, index) {
                return InkWell( 
                  child: SyncSessionWidget(_syncSessions[index]),
                  onTap: ()=>{
                      Scaffold.of(context).showSnackBar(
                      SnackBar(
                        content: Text(_syncSessions[index].sessionName),
                        backgroundColor: Colors.purple[200],
                        ))
                });
              });
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