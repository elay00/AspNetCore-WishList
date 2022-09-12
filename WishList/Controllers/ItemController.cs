﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var items = _context.Items.ToList();
            return View("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }


        [HttpPost]
        public IActionResult Create(WishList.Models.Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return View("Index");
        }

        public IActionResult Delete(int Id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == Id);
            _context.Items.Remove(item);
            _context.SaveChanges();
            return View("Index");
        }
    }
}