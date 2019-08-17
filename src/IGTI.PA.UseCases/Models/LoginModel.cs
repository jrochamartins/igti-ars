namespace IGTI.PA.UseCases.Models
{
    public class LoginModel : RegisterModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
