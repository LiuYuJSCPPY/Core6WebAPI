using Microsoft.EntityFrameworkCore;
using aspnetWebApi.Model;

namespace aspnetWebApi.Data
{
    public class ASPWewbApiContext : DbContext
    {
        public ASPWewbApiContext (DbContextOptions<ASPWewbApiContext> options) : base(options)
        {

        }

        public DbSet<Post> posts { get; set; }
    }
}
