using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcessing.Models
{
      
    [DisplayColumn("Name")]
     public class Customer
    {
        

        public int ID { get; set; }

        [Required]
        [Display(Name="Name")]  //web page label
        [Column("Name")]  //table column name
        public string AName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string State { get; set; }

        //navigation property, ossociated orders, not scaffolded. DONT scaffold after created
        public ICollection<Order> Orders { get; set; }
    }
}
