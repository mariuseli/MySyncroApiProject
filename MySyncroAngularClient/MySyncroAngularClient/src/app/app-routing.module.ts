import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddContactFormComponent } from './contacts/add-contact-form/add-contact-form.component';
import { ContactListComponent } from './contacts/contact-list/contact-list.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'list', component: ContactListComponent},
  { path: 'add', component: AddContactFormComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
