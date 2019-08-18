using IGTI.PA.Entities;
using IGTI.PA.UseCases.Adapters.Database;
using IGTI.PA.UseCases.Models;

namespace IGTI.PA.UseCases.Impl
{
    public class ValidateImpl : Validate
    {
        private readonly ProspectRepository _prospectRepository;

        public ValidateImpl(
            ProspectRepository prospectRepository)
        {
            _prospectRepository = prospectRepository;
        }

        public Steps? Validate(ValidateModel model)
        {
            //TODO: Check authentication code
            if (model.Code != "1111")
                return null;

            var prospect = _prospectRepository.Find(model.Uid);
            return prospect?.LastStep;
        }
    }
}
