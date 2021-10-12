using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EFCoreDb
{
    public class Category
    {
        public int CategoryId { get; set; }
                public string Name { get; set; }
    }
}
