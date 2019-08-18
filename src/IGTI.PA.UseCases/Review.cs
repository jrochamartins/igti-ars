using IGTI.PA.UseCases.Models;

namespace IGTI.PA.UseCases
{
    public interface Review
    {
        ReviewResponseModel Get(string uid);
        void Accept(ReviewAcceptModel model);
    }
}
