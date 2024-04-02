using Dapper;
using System.Data;

namespace ORM_Dapper
{
    public class DapperProductRepository : IProductRepository
    {

        //add connection to database ie: inversion of control
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

        //update product with UpdateProduct method       
        public void UpdateProduct(int productID, string updatedName)
        {
            _conn.Execute("Update products SET Name = @updatedName WHERE productID = @productID;",
                new { productID = productID, updatedName = updatedName });

        }

        //Delete product with this id from products table ,sales table, reviews table all at once
        public void DeleteProduct(int productId)
        {
            //this will delete this product with this id in the products table
            _conn.Execute("DELETE FROM products WHERE productID = @productID;",
                new { productId = productId });

            //this will delete this product with this id in the sales table
            _conn.Execute("DELETE FROM sales WHERE productID = @productID;",
                new { productId = productId });

            //this will delete this product with this id in the reviews table
            _conn.Execute("DELETE FROM reviews WHERE productID = @productID;",
                new { productId = productId });

        }

        //here taking our _conn object and using the Execute function to 
        //insert into the departments our (Name) column the values we want to insert
        //the @name column name which is the variable
        //and this object new{name=name} to represent the relationship btw the paramenter and the variable

        // _conn.Execute("INSERT INTO departments (Name) VALUES (@name)", new { name = name
        //}); 

        //so the string name = @name inside the new { }


    }
}
