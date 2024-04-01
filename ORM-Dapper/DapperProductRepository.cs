using Dapper;
using System.Data;

namespace ORM_Dapper
{
    public class DapperProductRepository : IProductRepository
    {

        //add connection to database
        private readonly IDbConnection _conn;

        //our constructor with the database connection
        public DapperProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }


        //Read in all the products
        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("Select * From Products");
        }

        //insert into the products table...take the _conn and use Execute method
        public void CreateProduct(string name, double price, int categoryID)
        {
            _conn.Execute("INSERT INTO products (name, price, categoryID) VALUES (@name, @price, @categoryID)", new { name = name, price = price, categoryID = categoryID });

        }//end createproduct method

        //here taking our _conn object and using the Execute function to 
        //insert into the departments our (Name) column the values we want to insert
        //the @name column name which is the variable
        //and this object new{name=name} to represent the relationship btw the paramenter and the variable

        // _conn.Execute("INSERT INTO departments (Name) VALUES (@name)", new { name = name
        //}); 

        //so the string name = @name inside the new { }


    }
}
