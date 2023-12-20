using Microsoft.AspNetCore.Mvc;
using ServerSideWebapi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSideWebapi.IRepository
{
    public interface IHomeRepository
    {
        string CheckApi();

     
        ResProduct GetPaginatedData(int pageNumber, int pageSize, string searchval,string sortColumn,string sortDirection);

        int GetTotalRecordsCount();
    }
}
