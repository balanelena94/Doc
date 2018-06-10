using ResidenceAdmin.DataAccess.Contracts;
using ResidenceAdmin.DomainModel;
using ResidenceAdmin.Persistency;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResidenceAdmin.DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IPersistencyContext persistencyContext;

        public EmployeeRepository(IPersistencyContext persistencyContext)
        {
            this.persistencyContext = persistencyContext;
        }

        Employee IEmployeeRepository.GetEmployeeById(int employeeId)
        {
            return persistencyContext.Get<Employee>(employeeId);
        }

    }
}
