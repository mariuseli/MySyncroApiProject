import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from './../shared/shared.module';
import { AddContactFormComponent } from './add-contact-form/add-contact-form.component';
import { ContactListComponent } from './contact-list/contact-list.component';
import { ContactServiceService } from './services/contact-service.service';

@NgModule({
  declarations: [ContactListComponent, AddContactFormComponent],
  imports: [
    CommonModule,
    SharedModule,

    // http client module
    HttpClientModule,

    // add ng*** syntaxis in html
    FormsModule,

    // add reactive forms module for formsgrour and validation
    ReactiveFormsModule
  ],
  providers: [ContactServiceService]
})
export class ContactsModule { }
