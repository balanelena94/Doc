using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace ResidenceAdmin.DomainModel
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Employee> AssignedEmployees { get; set; } 

        public List<Document> OwnedDocuments { get; set; }

    }
}
