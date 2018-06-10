using ResidenceAdmin.DataAccess.Contracts;
using ResidenceAdmin.DomainModel;
using System;
using System.Web.Http;

namespace ResidenceAdmin.Service.Controllers
{
    public class EmployeeController : ApiController
    {

        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        // GET: Employee
        public Employee GetEmployeesById([FromUri] Guid employeeId)
        {
            return employeeRepository.GetEmployeeById(employeeId);
        }
    }
}