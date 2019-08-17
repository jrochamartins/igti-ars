using IGTI.PA.Entities;
using IGTI.PA.UseCases.Adapters.Database;
using MongoDB.Driver;

namespace IGTI.PA.Database.Impl
{
    public class ProspectRepositoryImpl : ProspectRepository
    {
        private readonly DatabaseContext _context;

        public ProspectRepositoryImpl(
            DatabaseContext context)
        {
            _context = context;
        }

        public Prospect Find(string uid) =>
            _context.Prospects.Find(p => p.Uid == uid).FirstOrDefault();

        public void Add(Prospect entity) =>
            _context.Prospects.InsertOne(entity);
    }
}
