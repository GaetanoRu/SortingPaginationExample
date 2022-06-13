using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SortingPaginationExample.Data.Entities;
using SortingPaginationExample.Models;
using SortingPaginationExample.Services.Interfaces;
using System.Net.Mime;
using System.Threading.Tasks;

namespace SortingPaginationExample.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController (ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        /// <summary>
        /// Get the paginated customers list
        /// </summary>
        /// <param name="pageIndex">The index of the page to get</param>
        /// <param name="itemsPerPage">The numbers of elements to get</param>
        /// <response code="200">The customers list</response>
        [HttpGet]
        [ProducesDefaultResponseType]
        [ProducesResponseType(typeof(ListResultPagination<Customer>),StatusCodes.Status200OK)]
        public async Task<ListResultPagination<Customer>> GetCustomer([FromQuery(Name="page")] int pageIndex = 0,
                                                                      [FromQuery(Name ="size")] int itemsPerPage = 20)
        {

            var customer = await customerService.GetAsync(pageIndex, itemsPerPage);
            return customer;
        }
    }
}
