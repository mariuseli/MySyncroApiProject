import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilterContactsPipe } from './pipes/filter-contacts.pipe';



@NgModule({
  declarations: [FilterContactsPipe],
  imports: [
    CommonModule
  ],
  exports: [FilterContactsPipe]
})
export class SharedModule { }
