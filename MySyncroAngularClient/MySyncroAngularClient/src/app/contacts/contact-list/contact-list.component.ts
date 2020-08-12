import { Component, OnInit } from '@angular/core';
import { ContactModel } from './../../shared/models/contact.model';
import { ContactServiceService } from './../services/contact-service.service';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.scss']
})

export class ContactListComponent implements OnInit {

  contactList: ContactModel[];
  contactCount = 0;
  searchContactFilter: string;

  constructor(private service: ContactServiceService){
    service.getAllContactObservable().subscribe(
      x => {
        console.log(x);
        this.contactList = ContactModel.deserializeFromJsonArray(x);
        this.contactCount = this.contactList.length;
      }
    );
  }

  ngOnInit(): void {
  }

}
