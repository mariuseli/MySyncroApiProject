import 'package:uuid/uuid.dart';

class ContactModel{
  int id = 0;
  Uuid refId = new Uuid();
  DateTime creationDate = DateTime.now();
  String contactName;
  String contactEmail;
  String contactPhoneNumber;
  String contactDescription;

}