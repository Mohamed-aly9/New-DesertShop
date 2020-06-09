﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PieShop.Models;
using PieShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository, IWebHostEnvironment webHostEnvironment)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            DesertViewModel pieViewModel = new DesertViewModel
            {
                Pies = _pieRepository.AllPies
            };
            return View(pieViewModel);
        }
        [Authorize]
        public ViewResult AddPie()
        {
            DesertViewModel pieViewModel = new DesertViewModel
            {
                Categories = _categoryRepository.Categories              
            };
            return View(pieViewModel);
        }

        [Authorize]
        [HttpPost]
        public RedirectToActionResult AddPie(Pie pie)
        {
            if (pie == null)
                return RedirectToAction("AddPie");
            else
            {
                if(ModelState.IsValid)
                {
                    string uniqueFileName = UploadedFile(pie);
                    pie.PiePhoto = uniqueFileName;
                    _pieRepository.CreatePie(pie);
                }
            }
            return RedirectToAction("Index");
        }
        [Authorize]
        private string UploadedFile(Pie model)
        {
            string uniqueFileName = null;

            if (model.PiePhotoName != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PiePhotoName.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.PiePhotoName.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        [Authorize]
        public RedirectToActionResult RemovePie(Guid id)
        {
             var pie =  _pieRepository.GetPieById(id);
             _pieRepository.RemovePie(pie);
            return RedirectToAction("Index");
        }

        [Authorize]
        public ViewResult EditPie(Guid id)
        {
            var pie = _pieRepository.GetPieById(id);
            DesertViewModel pieViewModel = new DesertViewModel
            {
                Pie = pie,
                Categories = _categoryRepository.Categories
            };
            return View(pieViewModel);
        }

        [Authorize]
        [HttpPost]
        public RedirectToActionResult EditPie(Pie pie)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(pie);
                if(uniqueFileName != null) // if the user didn't change the photo, we won't assign a null to the photo name, we instead sent the photo name as hidden parameter, if a value is sent , the value would replace the hidden parameter
                    pie.PiePhoto = uniqueFileName;
               
                var the_pie = _pieRepository.GetPieById(pie.PieId);
                if (the_pie != null)
                    _pieRepository.EditPie(the_pie, pie);
            }
            return RedirectToAction("Index");
        }
        public IActionResult MakePieOfTheWeek(Guid id)
        {
            var pie = _pieRepository.GetPieById(id);
            _pieRepository.MakePieOfTheWeek(pie);
            return RedirectToAction("Index");
        }
        public IActionResult Details(Guid id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();

            return View(pie);
        }
    }
}
