using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrationEntityFramework
{
    static class CustomerDb
    {
        /// <summary>
        /// Returns all customer froms the database
        /// </summary>
        /// <returns></returns>
        public static List<Customer> GetCustomers()
        {
            //Create instance of DB Context
            var db = new BookRegistrationEntities();

            //Use DB Context to retrieve all customers
            //Use LINQ (Language Integrated Query)
            //to query database

            // LINQ Query Syntax
            //List<Customer> customers =
            //  (from c in db.Customer select c).ToList();
            //return customers;

            //LINQ Method Syntax - Same query as above
            List<Customer> customers = db.Customer.ToList();

            return customers;
        }

        /// <summary>
        /// Adds a customer. Returns the newly added customer with the CustomerId populated
        /// </summary>
        /// <param name="c">The new Customer to be added</param>
        /// <returns></returns>
        public static Customer AddCustomer(Customer c)
        {
            using(var context = new BookRegistrationEntities())
            {
                context.Customer.Add(c);
                context.SaveChanges();
                // Return newly added customer with CustomerID populated

                return c;
            }
        }

        public static Customer UpdateCustomer(Customer c)
        {
            using (var context = new BookRegistrationEntities())
            {
                context.Customer.Add(c);
                // Tell EF we are updating an existing entity
                context.Entry(c).State = EntityState.Modified;
                context.SaveChanges();
                return c;
            }
        }

        public static void DeleteCustomer(Customer c)
        {
            using (var context = new BookRegistrationEntities())
            {
                context.Customer.Add(c);
                context.Entry(c).State =EntityState.Deleted;
                int rowsAffecteed = context.SaveChanges();
            }
        }
    }
}
