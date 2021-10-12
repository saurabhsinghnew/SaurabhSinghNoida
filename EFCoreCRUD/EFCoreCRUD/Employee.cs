using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace EFCoreCRUD
{
    [Table("Employees", Schema = "dbo")]

    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }
        [Column(TypeName  = "varchar(50)")]
        [Required]
        public string Name { get; set; }
       
        [Column(TypeName = "varchar(250)")]
        [Required]
        public string Address { get; set; }


        [Column(TypeName = "varchar(250)")]
        
        public string ImagePath { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }
        [ForeignKey("DeptId")]
        public Department Department { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
    }
}
