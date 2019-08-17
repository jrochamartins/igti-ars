using IGTI.PA.UseCases.Adapters.Database;
using IGTI.PA.UseCases.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IGTI.PA.QueueConsumer.Handlers
{
    public class RegisterModelHandler : Handler<RegisterModel>
    {
        public RegisterModelHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override void Execute(RegisterModel payload)
        {
            var prospectRepository = _serviceProvider.GetService<ProspectRepository>();

            var prospect = prospectRepository.Find(payload.Uid);

            if (prospect is null)
                prospectRepository.Add(payload);
        }
    }
}
