using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PieShop.Models;
using PieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PieShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly ICakeRepository _cakeRepository;
        public ShoppingCartController(IPieRepository pieRepository, ICakeRepository cakeRepository, ShoppingCart shoppingCart)
        {
            _pieRepository = pieRepository;
            _cakeRepository = cakeRepository;
            _shoppingCart = shoppingCart;
        }
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }
        public RedirectToActionResult AddToCart(Guid id)
        {
            var pie = _pieRepository.GetPieById(id);
            var cake = _cakeRepository.GetCakeById(id);
            if (pie != null)
            {
                _shoppingCart.AddToCart(pie, 1);
            }
            else if (cake != null)
            {
                _shoppingCart.AddToCart(cake, 1);
            }
            return RedirectToAction("Index");
        }
    }
}
