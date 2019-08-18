using IGTI.PA.UseCases.Adapters.Queue;
using IGTI.PA.UseCases.Models;

namespace IGTI.PA.UseCases.Impl
{
    public class FinancialImpl : Financial
    {
        private readonly Producer _queueProducer;

        public FinancialImpl(
            Producer queueProducer)
        {
            _queueProducer = queueProducer;
        }

        public void Update(FinancialModel model)
        {
            _queueProducer.Send(model);
        }
    }
}
