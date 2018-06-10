using System;

namespace ResidenceAdmin.DomainModel
{
    public class EmployeeWorkInfo : Entity
    {
        public DateTime DateOfEmployment { get; set; }

        public DateTime Interruptions { get; set; }

        public Seniority Seniority { get; set; }

        public Type SeniorityType { get; set; }

    }
}
