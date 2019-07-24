using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrationEntityFramework
{
    /// <summary>
    /// Contains helper methods to manipulate book data in the database
    /// </summary>
    class BookDB
    {
        /// <summary>
        /// Retrieves all books sorted in alphabetical by title
        /// </summary>
        /// <returns></returns>
        public static List<Book> GetBooks()
        {
            // The using statement will force the compiler to create a try/finally . the finally will dispose of the db context
            using(var context = new BookRegistrationEntities())
            {
                //LINQ Query Syntax
                List<Book> books =
                    (from b in context.Book
                    orderby b.Title ascending
                    select b).ToList();
                return books;
            }
        }
    }
}
