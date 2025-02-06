using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public interface IUserMessageService
    {

        Task<List<ResultMessageDto>> GetAllMessageAsync();
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id);//receiver
        Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id);//sender
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        Task DeleteMessageAsync(int id);

        Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
    }
}
