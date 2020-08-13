using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderProcessing.Models;

namespace OrderProcessing.Data
{
    public class OrderProcessingContext : DbContext
    {
        public OrderProcessingContext (DbContextOptions<OrderProcessingContext> options)
            : base(options)
        {
        }

        public DbSet<OrderProcessing.Models.Customer> Customer { get; set; }

        public DbSet<OrderProcessing.Models.Order> Order { get; set; }

        public DbSet<OrderProcessing.Models.Product> Product { get; set; }

        public DbSet<OrderProcessing.Models.Employee> Employee { get; set; }
    }
}
