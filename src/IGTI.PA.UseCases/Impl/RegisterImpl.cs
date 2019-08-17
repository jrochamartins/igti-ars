using IGTI.PA.UseCases.Adapters.Database;
using IGTI.PA.UseCases.Adapters.Queue;
using IGTI.PA.UseCases.Models;

namespace IGTI.PA.UseCases.Impl
{
    public class RegisterImpl : Register
    {
        private readonly ProspectRepository _prospectRepository;
        private readonly Producer _queueProducer;

        public RegisterImpl(
            ProspectRepository prospectRepository,
            Producer queueProducer)
        {
            _prospectRepository = prospectRepository;
            _queueProducer = queueProducer;
        }

        public bool Create(RegisterModel model)
        {
            var prospect = _prospectRepository.Find(model.Uid);

            if (!(prospect is null))
                return false;

            _queueProducer.Send(model);
            return true;
        }
    }
}
