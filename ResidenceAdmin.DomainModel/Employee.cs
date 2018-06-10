using System;
using System.Collections.Generic;

namespace ResidenceAdmin.DomainModel
{
    public class Employee : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmpoyeeCode { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }

        public string Phone { get; set; }

        public EmployeeAddress Adress { get; set; }

        public EmployeeIdentity Identity { get; set; }
        
        public EmployeeWorkInfo WorkInfo { get; set; }

        public List<Document> PersonalDocuments { get; set; }
    }
}
