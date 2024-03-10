using Microsoft.EntityFrameworkCore;
using webapi.api;

namespace webapi.data
{
    public class ApplicationDBContext :DbContext
    {

        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }


        public DbSet<Comment> comments { get; set; }
        public DbSet<Stock> stocks { get; set; }

    }
}
