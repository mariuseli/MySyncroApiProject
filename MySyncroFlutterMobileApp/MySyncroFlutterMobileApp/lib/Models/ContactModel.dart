import 'package:MySyncroFlutterMobileApp/Models/ModelBase.dart';

class ContactModel extends ModelBase{
  String contactName;
  String contactEmail;
  String contactPhoneNumber;
  String contactDescription;
  int syncSessionId;

  ContactModel({
    this.contactName,
    this.contactEmail,
    this.contactPhoneNumber,
    this.contactDescription});

  factory ContactModel.fromJson(Map<String, dynamic> json) {
    var x= ContactModel(
      contactName: json['contactName'],
      contactEmail: json['contactEmail'],
      contactPhoneNumber: json['contactPhoneNumber'],
      contactDescription: json['contactDescription']
    );
    
    x.id = json['id'];
    x.refId = json['refId'];
    x.creationDate = DateTime.parse(json['creationDate']);

    return x;
  }
}