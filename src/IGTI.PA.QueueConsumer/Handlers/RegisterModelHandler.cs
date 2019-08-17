using IGTI.PA.UseCases.Adapters.Database;
using IGTI.PA.UseCases.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IGTI.PA.QueueConsumer.Handlers
{
    public class RegisterModelHandler : Handler<RegisterModel>
    {
        private readonly ProspectRepository _prospectRepository;

        public RegisterModelHandler(
            IServiceProvider serviceProvider)
        {
            _prospectRepository = serviceProvider.GetService<ProspectRepository>();
        }

        public override void Execute(RegisterModel payload)
        {
            var prospect = _prospectRepository.Find(payload.Uid);

            if (prospect is null)
                _prospectRepository.Add(payload);
        }
    }
}
