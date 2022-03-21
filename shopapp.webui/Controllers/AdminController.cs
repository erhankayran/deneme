using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopapp.business.Abstract;
using shopapp.entity;
using shopapp.webui.Model;

namespace shopapp.webui.Controllers
{
    [Authorize]
    public class AdminController: Controller
    {
        private IProductService _productService;
                public AdminController(IProductService productService)
                {
                    _productService=productService;
                }
        public IActionResult ProductList()
        {

            return View(new ProductListViewModel(){
            Products=_productService.GetAll()
            });
        }
        public IActionResult CreateProduct(){
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(ProductModel model)
        {
            var entity=new Product{
                Name=model.Name,
                Price=model.Price,
                Description=model.Description,
                Url=model.Url
            };
            _productService.Create(entity);
            return RedirectToAction("ProductList");
        }
        public IActionResult Edit(int? id){
        if(id==null)
        {
            return NotFound();
        }
         var entity=_productService.GetById((int)id);
        if(entity==null)
        {
            return NotFound();
        }
         var model=new ProductModel(){
                ProductId=entity.ProductId,
                Name=entity.Name,
                Price=entity.Price,
              
                Description=entity.Description,
                Url=entity.Url
             
         };
          return View(model);
        }
        [HttpPost]
        public IActionResult Edit(ProductModel model){
        var entity=_productService.GetById(model.ProductId);
        if(entity==null)
        {
            return NotFound();
        }
         entity.Name=model.Name;
         entity.Price=model.Price;
        
         entity.Description=model.Description;
         entity.Url=model.Url;
         
         _productService.Update(entity);
          
           return RedirectToAction("ProductList");
        }
        public IActionResult DeleteProduct(int productId)
        {
            var entity=_productService.GetById(productId);
            
            if(entity!=null)
            {
                _productService.Delete(entity);
            }
            return RedirectToAction("ProductList");
        }
    }
}