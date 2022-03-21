using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete.EfCore
{
    public class EfCoreProductRepository :
        EfCoreGenericRepository<Product, ShopContext>, IProductRepository
    {
        public Product GetProductDetails(string url)
        {
            throw new System.NotImplementedException();
        }
    }
}