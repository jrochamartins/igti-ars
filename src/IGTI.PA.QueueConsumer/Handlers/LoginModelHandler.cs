using IGTI.PA.Entities;
using IGTI.PA.UseCases.Adapters.Database;
using IGTI.PA.UseCases.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IGTI.PA.QueueConsumer.Handlers
{
    public class LoginModelHandler : Handler<LoginModel>
    {
        private readonly ProspectRepository _prospectRepository;

        public LoginModelHandler(
            IServiceProvider serviceProvider)
        {
            _prospectRepository = serviceProvider.GetService<ProspectRepository>();
        }

        public override void Execute(LoginModel payload)
        {
            var prospect = _prospectRepository.Find(payload.Uid);

            if (prospect is null)
            {
                prospect = new Prospect { Uid = payload.Uid };
                prospect.SetLogin(payload.Name, payload.Email, payload.Phone);
                _prospectRepository.Add(prospect);
            }

            prospect.SetLogin(payload.Name, payload.Email, payload.Phone);
            _prospectRepository.Update(prospect);
        }
    }
}
