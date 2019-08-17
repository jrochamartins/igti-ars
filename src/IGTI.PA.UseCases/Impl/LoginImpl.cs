using IGTI.PA.UseCases.Adapters.Queue;
using IGTI.PA.UseCases.Models;

namespace IGTI.PA.UseCases.Impl
{
    public class LoginImpl : Login
    {
        private readonly Producer _queueProducer;

        public LoginImpl(
            Producer queueProducer)
        {
            _queueProducer = queueProducer;
        }

        public void Enter(LoginModel model)
        {  
            //TODO: Sends email and/or sms with access code
            _queueProducer.Send(model);
        }
    }
}
