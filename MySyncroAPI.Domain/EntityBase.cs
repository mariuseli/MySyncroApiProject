using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySyncroAPI.Domain
{
    public class EntityBase{

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id {get;set;}
        public Guid RefId {get;set;}
        public DateTime CreationDate {get;set;}
    }
}