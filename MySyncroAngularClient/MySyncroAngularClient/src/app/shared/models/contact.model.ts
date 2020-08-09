
export class ContactModel
{
  Id: number;
  RefId: string ;
  CreationDate: string ;
  ContactName: string ;
  ContactEmail: string;
  ContactPhoneNumber: string ;
  ContactDescription: string ;

  constructor(field?: Partial<ContactModel>) {

    if (field){
      Object.assign(this, field);
    }
  }

  static deserializeModelFromJsonString(itemObject: any): ContactModel{
    // const itemObject = JSON.parse(jsonItemString);
    const newModel = new ContactModel();
    if (itemObject.id) { newModel.Id = parseInt(itemObject.id); }
    if (itemObject.refId) { newModel.RefId = itemObject.refId; }
    if (itemObject.ceationDate) { newModel.RefId = itemObject.ceationDate; }
    if (itemObject.contactName) { newModel.ContactName = itemObject.contactName; }
    if (itemObject.contactEmail) { newModel.ContactEmail = itemObject.contactEmail; }
    if (itemObject.ContactPhoneNumber) { newModel.ContactPhoneNumber = itemObject.contactPhoneNumber; }
    if (itemObject.ContactDescription) { newModel.ContactDescription = itemObject.contactDescription; }
    return newModel;
  }

  static deserializeFromJsonArray(itemsArray: any[]): ContactModel[] {
    // const itemsArray = JSON.parse(jsonString);
    const modelArray = new Array<ContactModel>();
    if (Array.isArray(itemsArray))
    {
      for (let i = 0; i < itemsArray.length; i++)
      {
        modelArray.push(this.deserializeModelFromJsonString(itemsArray[i]));
      }
    }else{
      return null;
    }

    return modelArray;
  }
}
