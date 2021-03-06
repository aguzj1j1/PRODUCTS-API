using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProductsAPI.Data.Request;
using ProductsAPI.Data.Context.Entitys;
using ProductsAPI.Data.Context;
 
namespace ProductsAPI.Models
{
    public class BuyDataAccess
    {
        
        public BuyDataAccess()
        {
        }

        #region GET
        
        public BuyDetailResponse Detail()
        {
            var response = new BuyDetailResponse();
            return response;
        } 
    
        public BuySummaryResponse Summary()
        {
            var response = new BuySummaryResponse();
            return response;
        } 

        public SalesDetailsResponse SalesDetails()
        {
            var response = new SalesDetailsResponse();
            return response;
        } 

        public SalesSummaryResponse SalesSummary()
        {
            var response = new SalesSummaryResponse();
            return response;
        } 

        #endregion
        
        
        #region POST

        public void Insert(BuyRequest request)
        {
            try
            {
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                BuysEntity buysEntity = new BuysEntity()
                {
                    UploadDate = request.UploadDate,
                    TotalAmount = request.TotalAmount,
                    IdClient = request.IdClient,
                    IdOrder = request.IdOrder
                };
                context.BuysEntity.Add(buysEntity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("BuyDataAccess.Insert : ERROR : "+ex.Message);
                throw;
            }
        }

        public void InsertDetail(BuyDetailRequest request)
        {
            try
            {
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                BuysDetailsEntity buysDetailsEntity = new BuysDetailsEntity()
                {
                    IdProduct = request.IdProduct,
                    Quantity = request.Quantity,
                    IdBuy = request.IdBuy
                };
                context.BuysDetailsEntity.Add(buysDetailsEntity);
                context.SaveChanges();                
            }
            catch (Exception ex)
            {
                Console.WriteLine("BuyDataAccess.InsertDetail : ERROR : "+ex.Message);
                throw;
            }
        }

        #endregion
    }
}
