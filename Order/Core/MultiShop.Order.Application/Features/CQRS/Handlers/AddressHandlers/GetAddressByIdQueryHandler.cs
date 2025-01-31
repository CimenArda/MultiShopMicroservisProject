using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetAddressByIdQueryResult
            {
                AddressID = values.AddressID,
                City = values.City,
                Detail1 = values.Detail1,
                District = values.District,
                UserID = values.UserID,
                ZipCode = values.ZipCode,
                Surname = values.Surname,
                Phone =values.Phone,
                Name = values.Name,
                Email = values.Email,
                Detail2 = values.Detail2,
                Description = values.Description,
                Country = values.Country
                
            };

        }



    }
}
