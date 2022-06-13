using Microsoft.EntityFrameworkCore;
using SortingPaginationExample.Data;
using SortingPaginationExample.Data.Entities;
using SortingPaginationExample.Models;
using SortingPaginationExample.Services.Interfaces;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace SortingPaginationExample.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext context;
        public OrderService(DataContext context)
        {
            this.context = context;
        }

        public async Task<ListResultPagination<Order>> GetAsync(int pageIndex, int itemsPerPage,string orderBy)
        {
            var query = context.Orders;

            var totalCount = await query.CountAsync();
            var totalPage = (int)Math.Ceiling((double)totalCount / itemsPerPage);
            var curruntPage = (pageIndex <= 0) ? 1 : pageIndex;

            var order = await query
                .OrderBy(orderBy)
                .Skip(pageIndex * itemsPerPage).Take(itemsPerPage+1)
                .ToListAsync();

      
            var result = new ListResultPagination<Order>(order.Take(itemsPerPage), totalCount, totalPage, curruntPage, order.Count > itemsPerPage);
            return result;

        }

    }
}

