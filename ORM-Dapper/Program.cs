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

        }
    }
}
