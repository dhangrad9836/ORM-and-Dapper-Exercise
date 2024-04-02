using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            //this code goes to the appsettings.json file to get the connection info
            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            //this code finalizes the above code to setup our connection located in appsettings
            string connString = config.GetConnectionString("DefaultConnection");
            //creates the connection to mysql
            IDbConnection conn = new MySqlConnection(connString);

            //pass in the conn object
            var departmentRepo = new DapperDepartmentRepository(conn);

            //add a new department
            departmentRepo.InsertDepartments("Johns New Department");

            var departments = departmentRepo.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine(department.DepartmentID);
                Console.WriteLine(department.Name);
                Console.WriteLine();
                Console.WriteLine();
            }



            //Create and read from the products table

            //1 pass in the conn to the DapperProductRepository
            var productRepo = new DapperProductRepository(conn);

            //add a new product
            productRepo.CreateProduct("Sharp TV 32inch", 600.00, 5);

            //2 call the GetAllProducts method
            var products = productRepo.GetAllProducts();

            //read in all the products
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine();
            }

            //update the products
            Console.WriteLine("What is the product ID you want to update? ");
            var prodID = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the new product name? ");
            var newName = Console.ReadLine();

            productRepo.UpdateProduct(prodID, newName);

            //delete the product
            Console.WriteLine("What is the product ID you want to delete? ");
            //reuse the prodID variable
            prodID = int.Parse(Console.ReadLine());

            productRepo.DeleteProduct(prodID);

        }
    }
}
