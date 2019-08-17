namespace IGTI.PA.Entities
{
    public class Prospect : Entity
    {
        public Prospect()
        {
            LastStep = Steps.Register;
        }

        public Steps LastStep { get; set; }

        public string Uid { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public void SetLogin(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
            LastStep = Steps.Login;
        }
    }
}
