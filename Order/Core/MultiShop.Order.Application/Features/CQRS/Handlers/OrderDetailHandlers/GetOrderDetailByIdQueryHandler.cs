﻿using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<OrderDetailByIdQueryResult> Handle(OrderDetailByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new OrderDetailByIdQueryResult
            {
                OrderDetailID = values.OrderDetailID,
                ProductAmount = values.ProductAmount,
                ProductID= values.ProductID,
                ProductName = values.ProductName,
                OrderingID = values.OrderingID,
                ProductPrice = values.ProductPrice,
                ProductTotalPrice = values.ProductTotalPrice
            };
        }
    }
}
