using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PieShop.Models;
using PieShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PieShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            DesertViewModel DesertViewModel = new DesertViewModel
            {
                Categories = _categoryRepository.Categories
            };
            return View(DesertViewModel);
          
        }
        [Authorize]
        public ViewResult AddCategory()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public RedirectToActionResult AddCategory(Category category)
        {
            _categoryRepository.CreateCategory(category);
            return RedirectToAction("Index");
        }
    }
}
