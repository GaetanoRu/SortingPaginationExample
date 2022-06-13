using Microsoft.EntityFrameworkCore;
using SortingPaginationExample.Data;
using SortingPaginationExample.Data.Entities;
using SortingPaginationExample.Models;
using SortingPaginationExample.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SortingPaginationExample.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext dataContext;
        public CustomerService(DataContext dataContext)
        {
            this.dataContext = dataContext; 
        }

        public async Task<ListResultPagination<Customer>> GetAsync(int pageIndex, int itemsPerPage)
        {
            var query = dataContext.Customers;

            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / itemsPerPage);
            var current = (pageIndex <= 0) ? 1 : pageIndex;

            var customer = await query
                .OrderBy(c => c.City)
                .Skip(pageIndex * itemsPerPage).Take(itemsPerPage + 1)
                .ToListAsync();


            var result = new ListResultPagination<Customer>(customer.Take(itemsPerPage),totalCount, totalPages, current, customer.Count > itemsPerPage);
            return result;
        }
    }
}
