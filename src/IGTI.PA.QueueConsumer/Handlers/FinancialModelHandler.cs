using IGTI.PA.UseCases.Adapters.Database;
using IGTI.PA.UseCases.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IGTI.PA.QueueConsumer.Handlers
{
    public class FinancialModelHandler : Handler<FinancialModel>
    {
        private readonly ProspectRepository _prospectRepository;

        public FinancialModelHandler(
            IServiceProvider serviceProvider)
        {
            _prospectRepository = serviceProvider.GetService<ProspectRepository>();
        }

        public override void Execute(FinancialModel payload)
        {
            var prospect = _prospectRepository.Find(payload.Uid);

            if (prospect is null)
                return;

            prospect.SetFinancial(payload.TotalPropertyValue, payload.CurrentlyWorking, payload.Company, payload.Position, payload.Earnings);
            _prospectRepository.Update(prospect);
        }
    }
}
