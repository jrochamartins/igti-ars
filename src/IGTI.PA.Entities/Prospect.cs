namespace IGTI.PA.Entities
{
    public class Prospect : Entity
    {
        public Steps LastStep { get; set; }

        public string Uid { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string PostalCode { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        private void SetStep(Steps step)
        {
            if (step > LastStep)
                LastStep = step;
        }

        public void SetLogin(
            string name,
            string email,
            string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
            SetStep(Steps.Login);
        }

        public void SetAddress(
            string postalCode,
            string addressLineOne,
            string addressLineTwo,
            string city,
            string state,
            string country)
        {
            PostalCode = postalCode;
            AddressLineOne = addressLineOne;
            AddressLineTwo = addressLineTwo;
            City = city;
            State = state;
            Country = country;
            SetStep(Steps.Address);
        }
    }
}
