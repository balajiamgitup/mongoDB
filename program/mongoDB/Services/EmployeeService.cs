using WebApplication4.models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
namespace WebApplication4.Services  
{
    public class EmployeeService
    {
        private readonly IMongoCollection<Employee> _employees;
        public EmployeeService(IEmployeeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _employees = database.GetCollection<Employee>(settings.EmployeesCollectionName);

        }
        public Employee Create(Employee emp)
        {
            _employees.InsertOne(emp);
            return emp;
        }
        public List<Employee> Get()
        {
            List<Employee> employees;
            employees = _employees.Find(emp => true).ToList();
            return employees;
        }

        public Employee Get(string id) =>
            _employees.Find<Employee>(emp => emp.Id == id).FirstOrDefault();


        public void Update(string id, Employee empIn)
        {
            _employees.ReplaceOne(emp => emp.Id == id, empIn);
        }

        //public Task< Employee> Delete(string id)
        //{

        //return  _employees.DeleteOne(emp => emp.Id == id);



        //}

        public void Delete(string id)
        {
            _employees.DeleteOne(emp => emp.Id == id);
        }
    }
}
