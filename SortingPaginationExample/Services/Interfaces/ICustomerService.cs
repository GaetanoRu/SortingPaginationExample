using SortingPaginationExample.Data.Entities;
using SortingPaginationExample.Models;
using System.Threading.Tasks;

namespace SortingPaginationExample.Services.Interfaces
{
    public interface ICustomerService
    {
        public Task<ListResultPagination<Customer>> GetAsync(int pageIndex, int itemsPerPage);
    }
}
