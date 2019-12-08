using ApplicationCore.Entities.BasketAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Specification
{
    public sealed class BasketWithItemSpecification : BaseSpecification<Basket>
    {
        public BasketWithItemSpecification(int basketId)
            :base(b => b.Id == basketId)
        {
            AddInclude(b => b.Items);
        }

        public BasketWithItemSpecification(string buyerId)
            :base(b => b.BuyerId == buyerId)
        {
            AddInclude(b => b.Items);
        }
    }
}
