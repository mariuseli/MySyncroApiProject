using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure; 

namespace MySyncroAPI.Persistence{
    public class MySyncroAPIFactory : IDesignTimeDbContextFactory<MySyncroAPIDatabaseContext>
    {
        public MySyncroAPIDatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MySyncroAPIDatabaseContext>();
            string connectionString = @"../MySyncroAPI/Data/MySyncroDatabase.db";
            optionsBuilder.UseSqlite("Filename=" + connectionString);

            return new MySyncroAPIDatabaseContext(optionsBuilder.Options);
        }
    }
}