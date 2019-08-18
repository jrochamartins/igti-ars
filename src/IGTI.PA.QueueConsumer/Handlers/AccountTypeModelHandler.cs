using IGTI.PA.UseCases.Adapters.Database;
using IGTI.PA.UseCases.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IGTI.PA.QueueConsumer.Handlers
{
    public class AccountTypeModelHandler : Handler<AccountTypeModel>
    {
        private readonly ProspectRepository _prospectRepository;

        public AccountTypeModelHandler(
            IServiceProvider serviceProvider)
        {
            _prospectRepository = serviceProvider.GetService<ProspectRepository>();
        }

        public override void Execute(AccountTypeModel payload)
        {
            var prospect = _prospectRepository.Find(payload.Uid);

            if (prospect is null)
                return;

            prospect.SetAccountType(payload.AccountType);
            _prospectRepository.Update(prospect);
        }
    }
}
