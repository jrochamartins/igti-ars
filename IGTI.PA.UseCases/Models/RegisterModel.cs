using IGTI.PA.Entities;

namespace IGTI.PA.UseCases.Models
{
    public class RegisterModel : Event
    {
        public string Uid { get; set; }

        public static implicit operator Prospect(RegisterModel m) => new Prospect { Uid = m.Uid };

    }
}
