using IGTI.PA.UseCases.Adapters.Database;
using IGTI.PA.UseCases.Models;

namespace IGTI.PA.UseCases.Impl
{
    public class RegisterImpl : Register
    {

        private readonly ProspectRepository _prospectRepository;

        public RegisterImpl(
            ProspectRepository prospectRepository)
        {
            _prospectRepository = prospectRepository;
        }

        public bool Create(RegisterModel model)
        {
            var prospect = _prospectRepository.Find(model.Uid);

            if (prospect is null)
            {
                return true;
            }

            return false;
        }
    }
}
