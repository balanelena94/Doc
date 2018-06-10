namespace ResidenceAdmin.DomainModel
{
    public class EmployeeIdentity : Entity
    {
        public string IdentityCard { get; set; }

        public string Uin { get; set; }

        public string PlaceOfBirth { get; set; }

        public string DateOfBirth { get; set; }

        public string MaritalStatus { get; set; }
    }
}
