﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommand
{
    public class RemoveOrderingCommand :IRequest
    {
        public RemoveOrderingCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
