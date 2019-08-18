using System;

namespace IGTI.PA.UseCases.Models
{
    public class ReviewResponseModel
    {
        public string Uid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Entities.AccountType AccountType { get; set; }
        public string PostalCode { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public decimal? TotalPropertyValue { get; set; }
        public bool? CurrentlyWorking { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public decimal? Earnings { get; set; }
        public Guid TermsCode { get; } = Guid.NewGuid();
        public string Terms
        {
            get
            {
                return "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley.";
            }
        }
    }
}
