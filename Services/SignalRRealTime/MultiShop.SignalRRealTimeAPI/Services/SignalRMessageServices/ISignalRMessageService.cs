namespace MultiShop.SignalRRealTimeAPI.Services.SignalRMessageServices
{
    public interface ISignalRMessageService
    {
        Task<int> GetTotalMessageCountByReceiverIDAsync(string id);

    }
}
