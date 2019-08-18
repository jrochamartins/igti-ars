using IGTI.PA.Entities;
using IGTI.PA.UseCases.Adapters.Database;
using IGTI.PA.UseCases.Adapters.Queue;
using IGTI.PA.UseCases.Models;
using System;

namespace IGTI.PA.UseCases.Impl
{
    public class ReviewImpl : Review
    {
        private readonly ProspectRepository _prospectRepository;
        private readonly TermsCodeCache _termsCode;
        private readonly Producer _queueProducer;

        public ReviewImpl(
            ProspectRepository prospectRepository,
            TermsCodeCache termsCode,
            Producer queueProducer)
        {
            _prospectRepository = prospectRepository;
            _queueProducer = queueProducer;
            _termsCode = termsCode;
        }

        public ReviewResponseModel Get(string uid)
        {
            var prospect = _prospectRepository.Find(uid);

            if (prospect is null)
                return null;

            if (prospect.LastStep < (Steps.Analysis - 1))
                throw new Exception("Step unauthorized.");

            var review = new ReviewResponseModel
            {
                Uid = prospect.Uid,
                Name = prospect.Name,
                Email = prospect.Email,
                Phone = prospect.Phone,
                AccountType = prospect.AccountType,
                PostalCode = prospect.PostalCode,
                AddressLineOne = prospect.AddressLineOne,
                AddressLineTwo = prospect.AddressLineTwo,
                City = prospect.City,
                State = prospect.State,
                Country = prospect.Country,
                TotalPropertyValue = prospect.TotalPropertyValue,
                CurrentlyWorking = prospect.CurrentlyWorking,
                Company = prospect.Company,
                Position = prospect.Position,
                Earnings = prospect.Earnings
            };

            _termsCode.Add(prospect.Uid, review.TermsCode);

            return review;
        }

        public void Accept(ReviewAcceptModel model)
        {
            var termsCode = _termsCode.Get(model.Uid);

            if (termsCode != model.TermsCode)
                throw new Exception("Invalid code.");

            _queueProducer.Send(model);
        }
    }
}
