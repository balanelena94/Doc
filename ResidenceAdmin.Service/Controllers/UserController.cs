using System.Linq;
using ResidenceAdmin.DataAccess.Contracts;
using ResidenceAdmin.DomainModel;
using System.Web.Http;
using System;
using System.Collections.Generic;

namespace ResidenceAdmin.Service.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            var request = Request;
        }

        [HttpPost]
        public IHttpActionResult AddUser([FromBody] User user)
        {
            userRepository.AddUser(user);
            return Ok();
        }

        [HttpGet]
        public List<Employee> GetAssignedEmployees([FromUri] Guid userId)
        {
            return userRepository.GetAssignedEmployees(userId);
        }
    }
}