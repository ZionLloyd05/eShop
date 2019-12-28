using ApplicationCore.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Specification
{
    public class CustomerOrdersWithItemsSpecification : BaseSpecification<Order>
    {
        public CustomerOrdersWithItemsSpecification(string buyerId)
            : base(o => o.BuyerId == buyerId)
        {
            AddInclude(o => o.OrderItems);
            AddInclude($"{nameof(Order.OrderItems)}.{nameof(OrderItem.ItemOrdered)}");
        }
    }
}
