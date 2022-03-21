using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using shopapp.business.Abstract;
using shopapp.data.Abstract;
using shopapp.webui.Model;

namespace shopapp.webui.Controllers
{
    // localhost:5000/home
    public class HomeController:Controller
    {      
        private IProductService _productService;
        public HomeController(IProductService productService)
        {
            this._productService=productService;
        }
        
        public IActionResult Index()
        {
           

            return RedirectToAction("Login","Account");
        }

    
       
    }
}