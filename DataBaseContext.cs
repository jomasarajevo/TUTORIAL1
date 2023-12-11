using Microsoft.EntityFrameworkCore;
using CallClient2023Web.Models;


namespace CallClient2023Web.Models
{
    public class DataBaseContext : DbContext

    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options): base(options) 
        {

        }

       public DbSet<CallClientModel> Anketaweb { get; set; }
       public DbSet<BazaBrojeva> BazaBrojeva { get; set; }
       

    }

}
