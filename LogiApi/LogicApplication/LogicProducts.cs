using DataApi.Models;
using DataApi.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiApi.LogicApplication
{
    public class LogicProducts
    {
        private ProductsRepository _ProductsRepository = new ProductsRepository();

        /// <summary>
        /// This method permit communicate the controller with the repository and save the product
        /// </summary>
        /// <param name="modelProduct"></param>
        /// <returns></returns>
        public async Task<ProductsModel>  SetProduct(ProductsModel modelProduct)
        {
            try
            {
              return await  _ProductsRepository.SetProduct(modelProduct);
            }
            catch (Exception e) { throw e; }
        }

        /// <summary>
        /// This method call to repository and get the products from there
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductsModel>> GetProducts()
        {
            try
            {
                return await  _ProductsRepository.GetProducts();
            }
            catch (Exception e) { throw e; }
        }

        /// <summary>
        /// This method permit call to repository and update a product
        /// </summary>
        /// <param name="modelProduct"></param>
        /// <returns></returns>
        public async Task<ProductsModel> UpdateProducts(ProductsModel modelProduct)
        {
            try
            {
                return await _ProductsRepository.GetProductById(modelProduct.idProduct).Do(async product => 
                {
                    product.nameProduct = modelProduct.nameProduct;
                    product.quantityAvaible = modelProduct.quantityAvaible;

                    await _ProductsRepository.UpdateProduct(product);
                });

            }
            catch (Exception e) { throw e; }
        }
    }
}
