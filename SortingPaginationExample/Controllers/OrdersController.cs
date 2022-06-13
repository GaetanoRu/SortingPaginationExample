using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SortingPaginationExample.Data.Entities;
using SortingPaginationExample.Models;
using SortingPaginationExample.Services.Interfaces;
using System.Net.Mime;
using System.Threading.Tasks;

namespace SortingPaginationExample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        /// <summary>
        /// Get the list of paginated and sorted orders
        /// </summary>
        /// <param name="pageIndex">The index of the page to get</param>
        /// <param name="itemPerPage">The numbers of elements to get</param>
        /// <param name="orderBy"> The name of the property for dynamic sorting</param>
        /// <response code="200">The orders list</response>
        [HttpGet]
        [ProducesDefaultResponseType]
        [ProducesResponseType((typeof(ListResultPagination<Order>)),StatusCodes.Status200OK)]
        public async Task<ListResultPagination<Order>> Get([FromQuery(Name ="page")]int? pageIndex,
                                                           [FromQuery(Name ="size")]int? itemPerPage,
                                                           [FromQuery(Name ="order")]string orderBy= "OrderDate DESC")
        {
            var orders = await orderService.GetAsync(pageIndex?? 1,itemPerPage?? 20,orderBy);
            return orders;

        }

    }
}
