using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSideWebapi.Model
{
    public class Product
    {
        public int MastCode { get; set; }
        public string ProductName { get; set; }

        public string ProductDetails { get; set; }
    }

      public class  ResProduct
       {
         public int ec { get; set; }
          public string em { get; set; }
        public  List<Product> pagelist { get; set; }
        }

    public class Pagedata
    {
        public int PageSize { get; set; } //start  pagesize how many entries per page
        public int PageNumber { get; set; } //end    pageNumber for which data is requested

        public string searchval { get; set; }
    }
    public class DataTableParams
    {
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public string Search { get; set; }
        public string sortColumn { get; set; }
        public string sortDirection { get; set; }
       
    }
}
