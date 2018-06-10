namespace ResidenceAdmin.DomainModel
{
    public class EmployeeAddress : Entity
    {
        public string Street { get; set; }

        public int Number { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string Bloc { get; set; }

        public string Entrance { get; set; }

        public string Apartment { get; set; }        
    }
}
