using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDb
{
   public class AppDbContext:DbContext
    {




        public AppDbContext (DbContextOptions<AppDbContext> options ) : base(options) 
        {
        


    }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        //{
        //    if (!optionBuilder.IsConfigured)
        //    {
        //        //   Server = myServerAddress; Database = myDataBase; User Id = myUsername; Password = myPassword;

        //        //Data Source=HONEY\SQLEXPRESS;Persist Security Info=False;User ID=sa;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False
        //        //  optionBuilder.UseSqlServer("data source=HONEY\\SQLEXPRESS; initial catalog=MyEFCoreDb; user id=sa; password=sa123 ");
        //        optionBuilder.UseSqlServer("Data Source=HONEY\\SQLEXPRESS; Initial Catalog=MyEFCoreTest123; User ID=sa; Password=sa123;");


        //    }
        //    base.OnConfiguring(optionBuilder);

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
               



                optionBuilder.UseSqlServer("Data Source=HONEY\\SQLEXPRESS; Initial Catalog=MyEFCoreTest123; User ID=sa; Password=sa123;");


            }
            base.OnConfiguring(optionBuilder);

        }
    }
}
