using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcessing.Models
{  
    public class Product
    {
        public int ID { get; set; }   //primary key

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [Range(5, 500)]
        public decimal Price { get; set; }
    }
}
