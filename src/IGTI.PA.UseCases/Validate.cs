using IGTI.PA.Entities;
using IGTI.PA.UseCases.Models;

namespace IGTI.PA.UseCases
{
    public interface Validate
    {
        Steps? Validate(ValidateModel model);
    }
}
