using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using ServerSideWebapi.IRepository;
using ServerSideWebapi.Model;

namespace ServerSideWebapi.Repository
{
    public class HomeRepository : IHomeRepository
    {
        clsDB dbNew = new clsDB(Config.ConStr);


        public string CheckApi()
        {
            return "API is started";
        }

        public int GetTotalRecordsCount()
        {
            try
            {
                int totalRecords = 0;
                ResProduct resProduct = new ResProduct();
                DataTable dt = dbNew.ExecuteDataTable("GetTotalRecordsCount");

                int j = dt.Rows.Count - 1;
                if (dt != null && dt.Rows.Count > 0)
                {
                    resProduct.ec = 0;
                    resProduct.em = "Success";

                    totalRecords = Convert.ToInt32(dt.Rows[0]["TotalRecords"]);

                }
                return totalRecords;
            }
            catch (Exception ex)
            {
                throw new Exception(" GetTotalRecordsCount: " + ex.Message); 
            }
        }


        

        public ResProduct GetPaginatedData(int pageNumber, int pageSize ,string  searchval,  string sortColumn,  string sortDirection)
        {
            try{
                List<Product> pagedata1 = new List<Product>();
                
                ResProduct resProduct = new ResProduct();
                //Pagedata pagedata = new Pagedata();
                SqlParameter[] p = new SqlParameter[5];
              
                p[0] = new SqlParameter("PageNumber", pageNumber);
                p[1] = new SqlParameter("PageSize", pageSize);
                //p[2] = new SqlParameter("SearchVal", searchval);
              
                p[2] = searchval != null ? new SqlParameter("SearchVal", searchval) : new SqlParameter("SearchVal", DBNull.Value);
                p[3] = sortColumn != null ? new SqlParameter("SortColumn", sortColumn) : new SqlParameter("SortColumn", DBNull.Value);
                p[4] = sortDirection != null ? new SqlParameter("SortDirection", sortDirection) : new SqlParameter("SortDirection", DBNull.Value);

                //DataTable dt = dbNew.ExecuteDataTable("GetPaginatedData", p);
                DataTable dt = dbNew.ExecuteDataTable("SP_GetData", p);
    
                int j = dt.Rows.Count - 1;
                if(dt!=null && dt.Rows.Count > 0)
                {
                    resProduct.em = "Success";
                    resProduct.ec = 0;

                    for (int i = 0; i <= j; i++)
                    {
                        Product product = new Product();
                        product.MastCode = Convert.ToInt32(dt.Rows[i]["MastCode"]);
                        product.ProductName = Convert.ToString(dt.Rows[i]["ProductName"]);
                        product.ProductDetails = Convert.ToString(dt.Rows[i]["ProductDetails"]);

                        pagedata1.Add(product);
                    }
                    resProduct.pagelist = pagedata1;
                }
                else
                {
                    resProduct.em = "Not found";
                    resProduct.ec = 106;
                }

                return resProduct;
            }
            catch(Exception ex)
            {
                throw new Exception("GetPaginatedData: " + ex.Message);
            }
           

        }

       
    }
}
