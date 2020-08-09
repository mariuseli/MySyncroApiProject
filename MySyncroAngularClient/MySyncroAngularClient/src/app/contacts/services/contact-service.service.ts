import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
// import 'rxjs/add/operator/map';
import { map } from 'rxjs/operators';
import { ContactModel } from './../../shared/models/contact.model';

@Injectable({
  providedIn: 'root'
})
export class ContactServiceService {

  private _remoteContactList: ContactModel[];

  constructor(private _httpClient: HttpClient) { }

  get RemoteContactList(): ContactModel[]{
    return this._remoteContactList;
  }

  getAllContacts(): void {
    this._httpClient.get('https://localhost:44329/Contacts/GetAllContacts/GetAllContacts')
    .subscribe(
      (result) => {
        console.log(result);
        this._remoteContactList = ContactModel.deserializeFromJsonArray(result as any[]);
      }
    );
  }

  /*getAllContactObservable(): Observable<ContactModel[]>{
    return this._httpClient.get('https://localhost:44329/Contacts/GetAllContacts/GetAllContacts').pipe(
      map(res => {
        return res.results.map(item => {
          return ContactModel.deserializeModelFromJsonString(item);
        });
      }));
  }*/

  getAllContactObservable(): Observable<ContactModel[]>{
    return this._httpClient.get<ContactModel[]>('https://localhost:44329/Contacts/GetAllContacts/GetAllContacts');
  }

  createNewContact(newContact: ContactModel): void{

    const otherEntry: any =
    {
      id: 0,
      refId: newContact.RefId,
      creationDate: newContact.CreationDate ,
      contactName: newContact.ContactName ,
      ontactEmail: newContact.ContactEmail ,
      contactPhoneNumber: newContact.ContactPhoneNumber ,
      contactDescription: newContact.ContactDescription
    };

    this._httpClient.post('https://localhost:44329/Contacts/RegisterContact/RegisterContact', otherEntry).subscribe(
      response => console.log(response),
      err => console.log(err));
  }

}
