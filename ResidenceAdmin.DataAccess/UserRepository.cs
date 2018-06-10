using ResidenceAdmin.DataAccess.Contracts;
using ResidenceAdmin.DomainModel;
using ResidenceAdmin.Persistency;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResidenceAdmin.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly IPersistencyContext persistencyContext;

        public UserRepository(IPersistencyContext persistencyContext)
        {
            this.persistencyContext = persistencyContext;
        }

        //void IUserRepository.AddUser(User user)
        //{
        //    persistencyContext.Insert(user);
        //    persistencyContext.SaveChanges();
        //}

        //List<Employee> IUserRepository.GetAssignedEmployees(Guid userId)
        //{
        //    return persistencyContext.Get<User>(userId).AssignedEmployees.ToList();
        //}
    }
}
