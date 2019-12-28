using ApplicationCore.Entities.OrderAggregate;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class OrderRepository : EfRepository<Order>, IOrderRepository
    {
        private readonly CatalogContext _dbContext;

        public OrderRepository(CatalogContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        Task<Order> IOrderRepository.GetByIdWithItemsAsync(int id)
        {
            return _dbContext.Orders
                .Include(o => o.OrderItems)
                .Include($"{nameof(Order.OrderItems)}.{nameof(OrderItem.ItemOrdered)}")
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
