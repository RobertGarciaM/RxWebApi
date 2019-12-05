using DataApi.ApplicationDbContext;
using DataApi.Models;
using System;
using System.Reactive.Linq;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataApi.Repositories.Products
{
    public class ProductsRepository
    {
        /// <summary>
        /// This method save the product into the database
        /// </summary>
        /// <param name="reserve"></param>
        /// <returns></returns>
        public IObservable<ProductsModel> SetProduct(ProductsModel reserve)
        {
            using (ApplicactionDbContext Db = new ApplicactionDbContext())
            {
                Db.Add(reserve);
                Db.SaveChanges();

                return Observable.Return(reserve);
            }
        }

        /// <summary>
        /// This method gets all products from database
        /// </summary>
        /// <returns></returns>
        public IObservable<List<ProductsModel>> GetProducts()
        {
            using (ApplicactionDbContext Db = new ApplicactionDbContext())
            {
                var products = from p in Db.ProductsModel
                               select p;

                return Observable.Return(products.ToList());
            }
        }

        /// <summary>
        /// This method gets the product by Id
        /// </summary>
        /// <param name="idProduct"></param>
        /// <returns></returns>
        public IObservable<ProductsModel> GetProductById(int idProduct)
        {
            using (ApplicactionDbContext Db = new ApplicactionDbContext())
            {
                var product = from p in Db.ProductsModel
                               where p.idProduct == idProduct
                               select p;

                return Observable.Return(product.FirstOrDefault());
            }
        }

        /// <summary>
        /// This method permit update a register products from database
        /// </summary>
        /// <param name="modelProduct"></param>
        /// <returns></returns>
        public IObservable<ProductsModel> UpdateProduct(ProductsModel modelProduct)
        {
            using (ApplicactionDbContext Db = new ApplicactionDbContext())
            {
                Db.Entry(modelProduct).State = EntityState.Modified;
                Db.SaveChanges();

                return Observable.Return(modelProduct);
            }
        }

    }
}
