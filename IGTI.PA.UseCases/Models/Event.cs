namespace IGTI.PA.UseCases.Models
{
    public class Event
    {
        public string EventName
        {
            get
            {
                return GetType().Name;
            }
        }
    }
}
