using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.business.Abstract
{
    public interface IProductService
    {
        Product GetById(int id);
        Product GetProductDetails(string url);
       
        List<Product> GetAll();
       
       
        void Create(Product entity);

        void Update(Product entity);
        void Delete(Product entity);
       
    }
}