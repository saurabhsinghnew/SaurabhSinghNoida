using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCRUD
{
  public  class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public AppDbContext()
        {
        }

      


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {



        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {

            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer("Data Source=HONEY\\SQLEXPRESS; Initial Catalog=MyEFCoreTest; User ID=sa; Password=sa123;");


            }
            base.OnConfiguring(optionBuilder);
        }



        //protected override  void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        //{

        //    if(!optionBuilder.IsConfigured)
        //    {
        //        optionBuilder.UseSqlServer("Data Source=HONEY\\SQLEXPRESS; Initial Catalog=MyEFCoreTest; User ID=sa; Password=sa123;");


        //    }
        //    base.OnConfiguring(optionBuilder);
        //}




    }
}
