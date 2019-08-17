using IGTI.PA.UseCases.Adapters.Queue;
using Newtonsoft.Json;
using System.Text;

namespace IGTI.PA.Queue.Impl
{
    public class ProducerImpl : Producer
    {
        private readonly QueueContext _context;

        public ProducerImpl(
            QueueContext context)
        {
            _context = context;
        }

        public void Send(object message) =>
            _context.Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message)));
    }
}
