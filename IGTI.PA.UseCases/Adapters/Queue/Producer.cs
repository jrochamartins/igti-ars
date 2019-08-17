namespace IGTI.PA.UseCases.Adapters.Queue
{
    public interface Producer
    {
        void Send(object message);
    }
}
