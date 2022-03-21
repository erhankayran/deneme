using System.Collections.Generic;
using shopapp.business.Abstract;
using shopapp.data.Abstract;
using shopapp.data.Concrete.EfCore;
using shopapp.entity;

namespace shopapp.business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Create(Product entity)
        {
            _productRepository.Create(entity);
        }

        public void Delete(Product entity)
        {
             _productRepository.Delete(entity);
        }

        public List<Product> GetAll()
        {
              return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Product GetProductDetails(string url)
        {
            return _productRepository.GetProductDetails(url);
        }

        public void Update(Product entity)
        {
            _productRepository.Update(entity);
        }
    }
}