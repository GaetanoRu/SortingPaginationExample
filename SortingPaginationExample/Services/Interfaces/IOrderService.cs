using SortingPaginationExample.Data.Entities;
using SortingPaginationExample.Models;
using System.Threading.Tasks;

namespace SortingPaginationExample.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<ListResultPagination<Order>> GetAsync(int pageIndex, int itemsPerPage, string orderBy);
    }
}
