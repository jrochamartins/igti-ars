using IGTI.PA.UseCases.Adapters.Database;
using IGTI.PA.UseCases.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IGTI.PA.QueueConsumer.Handlers
{
    public class ReviewAcceptModelHandler : Handler<ReviewAcceptModel>
    {
        private readonly ProspectRepository _prospectRepository;

        public ReviewAcceptModelHandler(
            IServiceProvider serviceProvider)
        {
            _prospectRepository = serviceProvider.GetService<ProspectRepository>();
        }

        public override void Execute(ReviewAcceptModel payload)
        {
            var prospect = _prospectRepository.Find(payload.Uid);

            if (prospect is null)
                return;

            prospect.SetFinish();
            _prospectRepository.Update(prospect);

            // TODO: Send to analisys.
        }
    }
}
