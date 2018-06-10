using System;

namespace ResidenceAdmin.DomainModel
{
    public class AccountingInfo : Entity
    {
        public string Stage { get; set; }

        public string Caracteristic { get; set; }

        public string PaymentType { get; set; }

    }
}
