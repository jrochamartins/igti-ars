namespace IGTI.PA.UseCases.Models
{
    public class Event
    {

        private string _eventName;

        public string EventName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_eventName))
                    return GetType().Name;
                return _eventName;
            }
            set
            {
                _eventName = value;
            }
        }
    }
}
