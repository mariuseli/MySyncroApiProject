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
    if(json['syncedContactList'] is List && json['syncedContactList'] != null)
    {
      var tableOfSomething =  json['syncedContactList'] ;
      for(var i = 0; i < tableOfSomething.length; i++)
      {
        valHala.add(ContactModel.fromJson(tableOfSomething[i]));
      }
    }

    var x = new SyncSessionModel(
      sessionName: json['sessionName'] as String,
      sessionItemsCount:  json['sessionItemsCount'],
      syncedContactList: valHala
    );
    
    x.id = json['id'] as int;
    x.refId = json['refId'] as String;
    x.creationDate = DateTime.tryParse(json['creationDate']);

    return x;
  }

}