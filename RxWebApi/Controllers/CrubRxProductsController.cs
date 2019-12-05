using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using DataApi.Models;
using LogiApi.LogicApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RxWebApi.Extensions;
using RxWebApi.Helpers;
using static RxWebApi.Enums.Enums;

namespace RxWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrubRxProductsController : ControllerBase
    {        
        /// <summary>
        /// This controller return all products
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetAllProducts")]
        public async Task<JsonResult> GetProducts()
        {

            var response = new JsonResultBody
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                LogicProducts _LogicProducts = new LogicProducts();
                response.Data = await _LogicProducts.GetProducts();
            }
            catch (Exception ex)
            {
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                response.Data = MessageApplication.ErrorApplication.ToDescriptionString();
                response.Errors.Add(ex.Message);
            }

            return new JsonResult(response);
        }

        /// <summary>
        /// This method permit to save a new product into the database
        /// </summary>
        /// <param name="modelProduct"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SetNewProducts")]
        public async Task<JsonResult> SetProducts(ProductsModel modelProduct)
        {

            var response = new JsonResultBody
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                LogicProducts _LogicProducts = new LogicProducts();
                response.Data = await _LogicProducts.SetProduct(modelProduct);
            }
            catch (Exception ex)
            {
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                response.Data = MessageApplication.ErrorApplication.ToDescriptionString();
                response.Errors.Add(ex.Message);
            }

            return new JsonResult(response);
        }

        /// <summary>
        /// This method call to the method to update from logic
        /// </summary>
        /// <param name="modelProduct"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateProducts")]
        public async Task<JsonResult> UpdateProducts(ProductsModel modelProduct)
        {

            var response = new JsonResultBody
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                LogicProducts _LogicProducts = new LogicProducts();
                response.Data = await _LogicProducts.UpdateProducts(modelProduct);
            }
            catch (Exception ex)
            {
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                response.Data = MessageApplication.ErrorApplication.ToDescriptionString();
                response.Errors.Add(ex.Message);
            }

            return new JsonResult(response);
        }
    }
}
