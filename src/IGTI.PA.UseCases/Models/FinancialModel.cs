namespace IGTI.PA.UseCases.Models
{
    public class FinancialModel : RegisterModel
    {
        public decimal? TotalPropertyValue { get; set; }
        public bool? CurrentlyWorking { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public decimal? Earnings { get; set; }
    }
}
