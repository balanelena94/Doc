using ResidenceAdmin.DomainModel;
using System;
using System.Collections.Generic;

namespace ResidenceAdmin.DataAccess.Contracts
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int employeeId);
    }
}
