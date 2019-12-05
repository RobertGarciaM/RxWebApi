using DataApi.Models;
using DataApi.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;

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
        public IObservable<ProductsModel>  SetProduct(ProductsModel modelProduct)
        {
            try
            {
              return  _ProductsRepository.SetProduct(modelProduct);
            }
            catch (Exception e) { throw e; }
        }

        /// <summary>
        /// This method call to repository and get the products from there
        /// </summary>
        /// <returns></returns>
        public IObservable<List<ProductsModel>> GetProducts()
        {
            try
            {
                return  _ProductsRepository.GetProducts();
            }
            catch (Exception e) { throw e; }
        }

        /// <summary>
        /// This method permit call to repository and update a product
        /// </summary>
        /// <param name="modelProduct"></param>
        /// <returns></returns>
        public IObservable<ProductsModel> UpdateProducts(ProductsModel modelProduct)
        {
            try
            {
                return _ProductsRepository.GetProductById(modelProduct.idProduct).Do(product =>
                {
                    product.nameProduct = modelProduct.nameProduct;
                    product.quantityAvaible = modelProduct.quantityAvaible;

                    _ProductsRepository.UpdateProduct(product);
                });
            }
            catch (Exception e) { throw e; }
        }
    }
}
