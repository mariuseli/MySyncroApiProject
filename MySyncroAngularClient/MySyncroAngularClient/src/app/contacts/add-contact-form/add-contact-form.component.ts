import { ContactModel } from './../../shared/models/contact.model';
import { ContactServiceService } from './../services/contact-service.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { v4 as uuidv4 } from 'uuid';

@Component({
  selector: 'app-add-contact-form',
  templateUrl: './add-contact-form.component.html',
  styleUrls: ['./add-contact-form.component.scss']
})
export class AddContactFormComponent implements OnInit {

  myAddContactForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private contactService: ContactServiceService) { }

  ngOnInit(): void {

    this.myAddContactForm = this.formBuilder.group({
      contactname: ['', [Validators.required, Validators.minLength(2)]],
      adressemail: ['', [Validators.required, Validators.minLength(5), Validators.email]],
      telephone: ['', [Validators.required]],
      description: ['', [Validators.minLength(0)]]
  });

  }

  // convenience getter for easy access to form fields
  get f() {return this.myAddContactForm.controls;}

  submitForm(): void{
    if (this.myAddContactForm.valid){
      const newEntry = new ContactModel();
      newEntry.ContactDescription = this.myAddContactForm.controls.description.value;
      newEntry.ContactName = this.myAddContactForm.controls.contactname.value;
      newEntry.ContactEmail = this.myAddContactForm.controls.adressemail.value;
      newEntry.ContactPhoneNumber = this.myAddContactForm.controls.telephone.value;
      newEntry.CreationDate = '2020-06-06';
      newEntry.Id = 0;
      newEntry.RefId = uuidv4();
      this.contactService.createNewContact(newEntry);
      console.log('Form is valid !!!');
      console.log(newEntry);
    }else{
      console.log('Invalid data in form !!!');
    }
  }

}
