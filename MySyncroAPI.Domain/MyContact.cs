using System;

namespace MySyncroAPI.Domain
{
    public class MyContact : EntityBase
    {
        public string ContactName {get;set;}
        public string ContactEmail{get;set;}
        public string ContactPhoneNumber {get;set;}
        public string ContactDescription {get;set;}
    }
}
