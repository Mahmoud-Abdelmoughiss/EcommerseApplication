﻿using EcommerseApplication.Models;

namespace EcommerseApplication.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        List<Product> GetPartnerProducts(int PartnerID);
        List<Product> GetPartnerProductsByCategoryID(int PartnerID, int CategoryID);
        List<Product> GetPartnerProductsBySubCategoryID(int PartnerID, int SubCategoryID);
        List<Product> GetAllWithInclude();
        List<Product> GetAllByCategoryID(int id);
        List<Product> GetAllBySubCategoryID(int id);
        Product Get(int Id);
        void Create(Product Product);
        public void IsDiscountFinish();
        void Update(int Id, Product Product);
        void ReduseQuantity(int ProductID, int DecreasedQuantity);
        void Delete(int Id);
        int Deletee(int Id);
    }
}
