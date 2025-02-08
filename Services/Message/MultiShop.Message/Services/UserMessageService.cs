﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.Context;
using MultiShop.Message.Dtos;
using MultiShop.Message.Entities;

namespace MultiShop.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _messageContext;
        private readonly IMapper _mapper;
        public UserMessageService(MessageContext messageContext, IMapper mapper)
        {
            _messageContext = messageContext;
            _mapper = mapper;
        }
        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            var value = _mapper.Map<UserMessage>(createMessageDto);
            await _messageContext.UserMessages.AddAsync(value);
            await _messageContext.SaveChangesAsync();
        }
        public async Task DeleteMessageAsync(int id)
        {
            var values = await _messageContext.UserMessages.FindAsync(id);
            _messageContext.UserMessages.Remove(values);
            await _messageContext.SaveChangesAsync();
        }
        public async Task<List<ResultMessageDto>> GetAllMessageAsync()
        {
            var values = await _messageContext.UserMessages.ToListAsync();
            return _mapper.Map<List<ResultMessageDto>>(values);
        }
        public async Task<GetByIdMessageDto> GetByIdMessageAsync(int id)
        {
            var values = await _messageContext.UserMessages.FindAsync(id);
            return _mapper.Map<GetByIdMessageDto>(values);
        }
        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.ReceiverID == id).ToListAsync();
            return _mapper.Map<List<ResultInboxMessageDto>>(values);
        }
        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.SenderID == id).ToListAsync();
            return _mapper.Map<List<ResultSendboxMessageDto>>(values);
        }

        public async Task<int> GetTotalMessageCountAsync()
        {
           var value = await _messageContext.UserMessages.CountAsync();
            return _mapper.Map<int>(value);
        }

        public async Task<int> GetTotalMessageCountByReceiverIDAsync(string id)
        {
            var value = await _messageContext.UserMessages.Where(x => x.ReceiverID == id).CountAsync();
            return _mapper.Map<int>(value);
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            var values = _mapper.Map<UserMessage>(updateMessageDto);
            _messageContext.UserMessages.Update(values);
            await _messageContext.SaveChangesAsync();
        }
    }
}
