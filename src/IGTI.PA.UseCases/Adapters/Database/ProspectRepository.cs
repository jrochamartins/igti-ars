using IGTI.PA.Entities;

namespace IGTI.PA.UseCases.Adapters.Database
{
    public interface ProspectRepository
    {
        Prospect Find(string uid);
        void Add(Prospect entity);
    }
}
