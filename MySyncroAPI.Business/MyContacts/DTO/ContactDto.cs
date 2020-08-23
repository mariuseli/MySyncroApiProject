using System;
using MySyncroAPI.Domain;

namespace MySyncroAPI.Business
{
    public class ContactDto : DtoBase
    {
        public string ContactName {get;set;}
        public string ContactEmail{get;set;}
        public string ContactPhoneNumber {get;set;}
        public string ContactDescription {get;set;}
        public int? MySyncSessionId { get; set; }

        public static ContactDto Projection(MyContact source)
        {
            return new ContactDto {
                Id = source.Id,
                RefId = source.RefId,
                CreationDate = source.CreationDate,
                ContactName = source.ContactName,
                ContactEmail = source.ContactEmail,
                ContactPhoneNumber = source.ContactPhoneNumber,
                ContactDescription = source.ContactDescription,
                MySyncSessionId = source.MySyncSessionId
            };
        }
    }
}