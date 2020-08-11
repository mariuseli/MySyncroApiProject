import { environment } from './../../../environments/environment.prod';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
// import 'rxjs/add/operator/map';
import { map } from 'rxjs/operators';
import { ContactModel } from './../../shared/models/contact.model';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ContactServiceService {

  private _remoteContactList: ContactModel[];

  constructor(private _httpClient: HttpClient, private _router: Router) { }

  get RemoteContactList(): ContactModel[]{
    return this._remoteContactList;
  }

  getAllContacts(): void {
    /*this._httpClient.get('https://localhost:44329/Contacts/GetAllContacts/GetAllContacts')*/
    this._httpClient.get(environment.contactApiListingUrl)
    .subscribe(
      (result) => {
        console.log(result);
        this._remoteContactList = ContactModel.deserializeFromJsonArray(result as any[]);
      }
    );
  }

  getAllContactObservable(): Observable<ContactModel[]>{
    return this._httpClient.get<ContactModel[]>(environment.contactApiListingUrl);
  }

  createNewContact(newContact: ContactModel): void{

    const otherEntry: any =
    {
      id: 0,
      refId: newContact.RefId,
      creationDate: newContact.CreationDate ,
      contactName: newContact.ContactName ,
      contactEmail: newContact.ContactEmail ,
      contactPhoneNumber: newContact.ContactPhoneNumber ,
      contactDescription: newContact.ContactDescription
    };

    this._httpClient.post(environment.contactApiRegisterUrl, otherEntry).subscribe(
      response => {
        console.log(response);
        this._router.navigate(['/list']);
      },
      err => {
        console.log(err);
      });
  }

}
