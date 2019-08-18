using IGTI.PA.UseCases.Adapters.Queue;
using IGTI.PA.UseCases.Models;

namespace IGTI.PA.UseCases.Impl
{
    public class AddressImpl : Address
    {
        private readonly Producer _queueProducer;

        public AddressImpl(
            Producer queueProducer)
        {
            _queueProducer = queueProducer;
        }

        public void Update(AddressModel model)
        {
            _queueProducer.Send(model);
        }
    }
}
