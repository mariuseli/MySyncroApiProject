using System;
using System.Text.Json;
using MySyncroAPI.Business;

namespace MySyncroAPI.Models
{
    public class ContactModel
    {
        public int Id {get;set;}
        public string RefId {get;set;}
        public string CreationDate {get;set;}
        public string ContactName {get;set;}
        public string ContactEmail{get;set;}
        public string ContactPhoneNumber {get;set;}
        public string ContactDescription {get;set;}

        public static ContactModel FromText(string jsonString)
        {
            try
            {
                var resultOfDeserialization = JsonSerializer.Deserialize<ContactModel>(jsonString, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                return resultOfDeserialization;
            }catch(Exception e)
            {
                throw e;
            }
        }

        public static ContactModel FromDTO(ContactDto contactDto)
        {
            return new ContactModel
            {
                Id = contactDto.Id,
                RefId = contactDto.RefId.ToString(),
                CreationDate = contactDto.CreationDate.ToString("YYYY-MM-dd HH:mm:ss"),
                ContactDescription = contactDto.ContactDescription,
                ContactEmail = contactDto.ContactEmail,
                ContactName = contactDto.ContactName,
                ContactPhoneNumber = contactDto.ContactPhoneNumber
            };
        }

        public ContactDto ToDto()
        {
            return new ContactDto
            {
                Id = this.Id,
                RefId = new Guid (this.RefId),
                CreationDate = DateTime.Parse( this.CreationDate),
                //CreationDate = DateTime.Parse( this.CreationDate, "YYYY-MM-dd HH:mm:ss"),
                ContactDescription = this.ContactDescription,
                ContactEmail = this.ContactEmail,
                ContactName = this.ContactName,
                ContactPhoneNumber = this.ContactPhoneNumber
            };
        }
    }
}