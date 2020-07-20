using System;
using Microsoft.EntityFrameworkCore;
using MySyncroAPI.Domain;

namespace MySyncroAPI.Persistence
{
    public class MySyncroAPIDatabaseContext: DbContext
    {
        public DbSet<MyContact> MyContacts{get;set;}
        public MySyncroAPIDatabaseContext(DbContextOptions<MySyncroAPIDatabaseContext> options) : base(options)
        {
            this.Database.Migrate();
        }
    }
}
