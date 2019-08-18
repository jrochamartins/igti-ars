using IGTI.PA.UseCases.Adapters.Queue;
using IGTI.PA.UseCases.Models;

namespace IGTI.PA.UseCases.Impl
{
    public class AccountTypeImpl : AccountType
    {
        private readonly Producer _queueProducer;

        public AccountTypeImpl(
            Producer queueProducer)
        {
            _queueProducer = queueProducer;
        }

        public void Update(AccountTypeModel model)
        {
            _queueProducer.Send(model);
        }
    }
}
