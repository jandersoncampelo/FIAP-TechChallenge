namespace InvestmentPortal.EventBus
{
    public interface IProcessData
    {
        Task Process(CustomMessage message);
    }
}
