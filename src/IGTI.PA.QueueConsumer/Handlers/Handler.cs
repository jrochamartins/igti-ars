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
        public abstract void Execute(T payload);

        public void Handle(byte[] message)
        {
            try
            {
                var body = Encoding.UTF8.GetString(message);
                if (body.Contains(typeof(T).Name))
                {
                    var model = JsonConvert.DeserializeObject<T>(body);
                    Execute(model);
                }
            }
            catch
            {   
            }
        }
    }
}
