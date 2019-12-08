using ApplicationCore.Entities.BasketAggregate;
using ApplicationCore.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ardalis.GuardClauses
{
    public static class BasketGuards
    {
        public static void NullBasket(this IGuardClause guardClause, int basketId, Basket basket)
        {
            if (basket == null)
                throw new BasketNotFoundException(basketId);
        }
    }
}
