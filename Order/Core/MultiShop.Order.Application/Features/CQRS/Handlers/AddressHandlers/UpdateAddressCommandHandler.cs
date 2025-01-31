using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            var value = await _repository.GetByIdAsync(command.AddressID);
            value.Detail1 = command.Detail1;
            value.District = command.District;
            value.City = command.City;
            value.UserID = command.UserID;
            value.Surname = command.Surname;
            value.Phone = command.Phone;
            value.Country = command.Country;
            value.Detail2 = command.Detail2;
            value.District = command.District;
            value.ZipCode = command.ZipCode;
            value.Email = command.Email;
            value.Name = command.Name;
            value.Description = command.Description;

            await _repository.UpdateAsync(value);
        }
    }
}
