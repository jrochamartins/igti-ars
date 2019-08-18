using IGTI.PA.UseCases.Adapters.Database;
using IGTI.PA.UseCases.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IGTI.PA.QueueConsumer.Handlers
{
    class AddressModelHandler : Handler<AddressModel>
    {
        private readonly ProspectRepository _prospectRepository;

        public AddressModelHandler(
            IServiceProvider serviceProvider)
        {
            _prospectRepository = serviceProvider.GetService<ProspectRepository>();
        }

        public override void Execute(AddressModel payload)
        {
            var prospect = _prospectRepository.Find(payload.Uid);

            if (prospect is null)
                return;

            prospect.SetAddress(payload.PostalCode, payload.AddressLineOne, payload.AddressLineTwo, payload.City, payload.State, payload.Country);
            _prospectRepository.Update(prospect);
        }
    }
}
