namespace ORM_Dapper
{
    public interface IDepartmentRepository
    {
        //this is an IEnumerable of Department type from our Department class we created
        //for a collection of Departments
        public IEnumerable<Department> GetAllDepartments();
    }
}
