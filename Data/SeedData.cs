using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcessing.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OrderProcessingContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<OrderProcessingContext>>()))
            {
                // Look for any customers or products.
                if (context.Customer.Any() || context.Product.Any())
                {
                    return;   // DB has been seeded
                }

                context.Customer.AddRange(
                    new Customer
                    {
                        AName = "Fred Smith",
                        City = "Cleveland",
                        State = "OH"
                    },
                    new Customer
                    {
                        AName = "Sue Jones",
                        City = "Pittsburg",
                        State = "PA"
                    }

                );
                context.SaveChanges();

                context.Product.AddRange(
                 new Product
                 {
                     Name = "Drill Press",
                     Price = 199.99m
                 },
                 new Product
                 {
                     Name = "Screwdriver",
                     Price = 8.99m
                 }

             );
                context.SaveChanges();

                context.Employee.AddRange(
                 new Employee
                 {
                     Name = "Marvin Jones",
                     Title = "Sales Rep"
                 },
                 new Employee
                 {
                     Name = "Jeo Leo",
                     Title = "CEO"
                 }


             );
                context.SaveChanges();

                context.Order.AddRange(
                 new Order
                 {
                     ID = 1001,
                     CustomerID = 1,
                     ProductID = 1,
                     EmployeeID = 1,
                     OrderDate = new DateTime(2018, 01, 20),
                     Quantity = 1
                 },
                 new Order
                 {
                     ID = 1004,
                     CustomerID = 2,
                     ProductID = 1,
                     EmployeeID = 3,
                     OrderDate = new DateTime(2018, 01, 20),
                     Quantity = 34
                 },
                 new Order
                 {
                     ID = 1005,
                     CustomerID = 1,
                     ProductID = 3,
                     EmployeeID = 2,
                     OrderDate = new DateTime(2018, 01, 20),
                     Quantity = 1
                 }

             ); ;
                context.SaveChanges();
            }
        }
    }
}
