using Dapper;
using System.Data;

namespace ORM_Dapper
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        //Step 10 all of our methods from accessing the database will live here

        //add a readonly for IDbconnection and best practice is to use _conn
        private readonly IDbConnection _conn;

        //constructor for everytime we create an instance of ths class we 
        //must pass in an instance for a connection to the database
        public DapperDepartmentRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        //now we can return a _conn object and use it to query the database
        //for the department and to select * from Department
        public IEnumerable<Department> GetAllDepartments()
        {
            //this will return our IEnumerable collection of objects from department in SQL
            return _conn.Query<Department>("Select * From Departments");
        }

        //Step 12 to insert method we pass in a string name parameter which comes 
        //from the column we want to add to which is the name column from departments
        public void InsertDepartments(string name)
        {
            //here taking our _conn object and using the Execute function to 
            //insert into the departments our (Name) column the values we want to insert
            //the @name column name which is the variable
            //and this object new{name=name} to represent the relationship btw the paramenter and the variable
            _conn.Execute("INSERT INTO departments (Name) VALUES (@name)", new { name = name }); //so the string name = @name inside the new { }
        }
    }
}
