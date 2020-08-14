import 'dart:convert';

import 'package:MySyncroFlutterMobileApp/Models/ContactModel.dart';
import 'package:MySyncroFlutterMobileApp/Models/ModelBase.dart';

class SyncSessionModel extends ModelBase{
  String sessionName;
  int sessionItemsCount;
  List<ContactModel> syncedContactList;


  
  SyncSessionModel({
    this.sessionName,
    this.sessionItemsCount,
    this.syncedContactList});

  factory SyncSessionModel.fromJson(Map<String, dynamic> json) {

    List<ContactModel> valHala = new List<ContactModel>();
    if(json['syncedContactList'] != null)
    {
      var tableOfSomething = jsonDecode(json['syncedContactList']);
      for(var i = 0; i < tableOfSomething.length; i++)
      {
        valHala.add(ContactModel.fromJson(tableOfSomething[i]));
      }
    }

    var x= SyncSessionModel(
      sessionName: json['sessionName'],
      sessionItemsCount: int.parse(json['sessionItemsCount']),
      syncedContactList: valHala
    );
    
    x.id = json['id'];
    x.refId = json['refId'];
    x.creationDate = DateTime.parse(json['creationDate']);

    return x;
  }
}