import 'package:MySyncroFlutterMobileApp/Models/SyncSessionModel.dart';
import 'package:flutter/material.dart';

class SyncSessionWidget extends StatelessWidget
{
  SyncSessionModel _currentSyncSession;
  
  SyncSessionWidget(SyncSessionModel currentSyncSession){
    _currentSyncSession = currentSyncSession;
  }

  @override
  Widget build(BuildContext context) {

    return Container(
      child: Row(
        children: [
          Text(_currentSyncSession.creationDate.toString()),
          Container(
            color: Color.fromARGB(255, 3, 146, 206),
            padding: EdgeInsets.all(15.0),
            child: Row(children: [
               Text(_currentSyncSession.sessionName, textAlign: TextAlign.start, style: TextStyle(fontFamily: 'UbuntuCondensed')),
                Spacer(),
               Text(_currentSyncSession.sessionItemsCount.toString(), textAlign: TextAlign.end, style: TextStyle( fontFamily: 'YanoneKaffeesatz', fontWeight: FontWeight.w900))],
            ),
          )]
      )
    );
  }
}