using Microsoft.AspNetCore.Mvc;
using ServerSideWebapi.Model;
using ServerSideWebapi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSideWebapi.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class HomeController : Controller
    {
        private readonly HomeRepository _homeRepository;

        public HomeController(HomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        [HttpGet("checkapi")]
        public IActionResult CheckApi()
        {
            var ans = _homeRepository.CheckApi();
            return Ok(ans);
        }

     

        [HttpPost]
        [Route("GetPaginatedData")]
        public IActionResult GetPaginatedData([FromBody] DataTableParams data)
        {
            //int pageNumber = (data.Start == 0) ? 1 : data.Start;
            int pageNumber = data.Start / data.Length + 1; // Calculate page number
         

          
         
            int pageSize = data.Length;
            string search = data.Search;
            string sortColumn = data.sortColumn;
            string sortDirection = data.sortDirection;
           

            List<Product> product = new List<Product>();
            //ResProduct resproduct = new ResProduct();
             
            var paginatedData = _homeRepository.GetPaginatedData(pageNumber, pageSize, search, sortColumn, sortDirection);
            
                   
            int totalRecords = _homeRepository.GetTotalRecordsCount();



            return Json(new
            {
                draw = data.Draw,
                recordsTotal = totalRecords,
            
                recordsFiltered = totalRecords,
                data = paginatedData.pagelist
            }) ; 
        }
    }
}
