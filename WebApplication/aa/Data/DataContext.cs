using Microsoft.EntityFrameworkCore;
using Project.Model;

namespace Project.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {

        }
        /*
         * 
         */
        public DbSet<Student> Students { get; set; }
    }
}
