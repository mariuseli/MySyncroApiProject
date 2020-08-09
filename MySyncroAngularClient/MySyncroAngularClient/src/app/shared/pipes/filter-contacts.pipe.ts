import { ContactModel } from './../models/contact.model';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filterContacts',
  pure: true
})
export class FilterContactsPipe implements PipeTransform {

  transform(value: ContactModel[], searchedValue: string): ContactModel[] {

    if (!value || !searchedValue) {
      return value;
    }

    // filter items array, items which match and return true will be
    // kept, false will be filtered out
    return value.filter(item => item.ContactName.toLowerCase().indexOf(searchedValue.toLowerCase()) !== -1);
  }
}
