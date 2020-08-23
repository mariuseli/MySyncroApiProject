import 'package:MySyncroFlutterMobileApp/CustomWidget/CustomTextStyles/CustomTextStyles.dart';
import 'package:MySyncroFlutterMobileApp/Models/SyncSessionModel.dart';
import 'package:flutter/material.dart';

class SyncSessionWidget extends StatefulWidget {
  SyncSessionModel _currentSyncSession;

  SyncSessionWidget(SyncSessionModel currentSyncSession) {
    print(currentSyncSession);
    _currentSyncSession = currentSyncSession;
  }

  @override
  _SyncSessionWidgetState createState() => _SyncSessionWidgetState();
}

class _SyncSessionWidgetState extends State<SyncSessionWidget> {
  @override
  Widget build(BuildContext context) {
    double desiredWidth = MediaQuery.of(context).size.width * 0.8;
    double desiredHeight = 70.0;
    String dateString =
        "${widget._currentSyncSession.creationDate.day.toString().padLeft(2, '0')}/${widget._currentSyncSession.creationDate.month.toString().padLeft(2, '0')}/${widget._currentSyncSession.creationDate.year.toString()}";
    return 
      Container(
        width: desiredWidth,
        padding: EdgeInsets.all(20.0),          
        child: Column(children: [
        Container(
            alignment: Alignment.centerLeft,
            margin: EdgeInsets.only(bottom: 5),
            child: Text(dateString,
                textAlign: TextAlign.left,
                style:
                    TextStyle(fontSize: 20, fontFamily: 'YanoneKaffeesatz'))),
        Container(
          width: double.infinity,
          height: desiredHeight,
          padding: EdgeInsets.all(15.0),
          decoration: BoxDecoration(
            /*color: Color.fromARGB(255, 3, 146, 206),*/
            color: Color.fromARGB(255, 111, 0, 183),
            borderRadius: BorderRadius.all(Radius.circular(10.0))),            
          child: Column(
            children: [
              Align(alignment:Alignment.topLeft, child: Text(widget._currentSyncSession.sessionName.toString(),
                  textAlign: TextAlign.left,
                  style: TextStyle(fontFamily: 'UbuntuCondensed', color: Colors.white))),
              Align(alignment:Alignment.bottomRight, child:Text(widget._currentSyncSession.sessionItemsCount.toString(),
                  textAlign: TextAlign.right,
                  style: CustomTextStyles.getSyncSessionCardHeaderStyle()))
            ],
          ),
        )
      ]));
  }
}
