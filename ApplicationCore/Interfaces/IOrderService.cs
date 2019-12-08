﻿using ApplicationCore.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(int basketId, Address shippingAddress);
    }
}
