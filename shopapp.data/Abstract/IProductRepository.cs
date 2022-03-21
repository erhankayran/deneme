using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.data.Abstract
{
    public interface IProductRepository: IRepository<Product>
    {
       
        Product GetProductDetails(string url);
        
    }
}