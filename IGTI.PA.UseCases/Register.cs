using IGTI.PA.UseCases.Models;

namespace IGTI.PA.UseCases
{
    public interface Register
    {
        bool Create(RegisterModel model);
    }
}
