namespace InvestmentPortal.EventBus
{
    public interface IProcessData
    {
        Task Process(InvestmentOrderMessage message);
    }
}
