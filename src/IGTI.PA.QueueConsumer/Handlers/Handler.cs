using IGTI.PA.UseCases.Models;
using Newtonsoft.Json;
using System;
using System.Text;

namespace IGTI.PA.QueueConsumer.Handlers
{
    public interface Handler
    {
        void Handle(byte[] message);
    }

    public abstract class Handler<T> : Handler where T : Event
    {
        protected readonly IServiceProvider _serviceProvider;

        public Handler(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public abstract void Execute(T payload);

        public void Handle(byte[] message)
        {
            try
            {
                var eventModel = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(message));
                if (typeof(T).Name == eventModel.EventName)
                    Execute(eventModel);
            }
            catch
            {
            }
        }
    }
}
