import 'dart:convert';
import 'package:MySyncroFlutterMobileApp/Models/ContactModel.dart';
import 'package:MySyncroFlutterMobileApp/Models/SyncSessionModel.dart';
import 'package:http/http.dart' as http;

class ContactService{
  var client = http.Client();

  static Future<List<ContactModel>> getContactList() async {
    var client = http.Client();
    List<ContactModel> listOfContacts = new List<ContactModel>();
    try {
      var response = await client.get('https://mysyncroapi20200809112720.azurewebsites.net/Contacts/GetAllContacts');
      if(response.statusCode == 200){
        var returnObject = jsonDecode(response.body);
        if(returnObject is List){
          for(var i = 0; i < returnObject.length; i++){
            listOfContacts.add(ContactModel.fromJson(returnObject[i]));
          }
        }
      }
    } finally {
      client.close();
    }

    return listOfContacts;
  }

  static Future<List<SyncSessionModel>> getSyncSessions() async {
    var client = http.Client();
    List<SyncSessionModel> syncSessions = new List<SyncSessionModel>();
    try {
      var response = await client.get('https://mysyncroapi20200809112720.azurewebsites.net/SyncSession/GetSyncSessions');
      if(response.statusCode == 200){
        var returnObject = jsonDecode(response.body);
        if(returnObject is List){
          for(var i = 0; i < returnObject.length; i++){
            syncSessions.add(SyncSessionModel.fromJson(returnObject[i]));
          }
        }
      }
    } finally {
      client.close();
    }

    return syncSessions;
  }
 
}