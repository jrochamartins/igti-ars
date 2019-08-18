namespace IGTI.PA.UseCases.Models
{
    public class AddressModel : RegisterModel
    {
        public string PostalCode { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
