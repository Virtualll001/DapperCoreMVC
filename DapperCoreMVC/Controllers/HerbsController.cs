using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DapperCoreMVC.Data;
using DapperCoreMVC.Models;
using DapperCoreMVC.Repository;

namespace DapperCoreMVC.Controllers
{
    public class HerbsController : Controller
    {
        private readonly IHerbRepository _herbRepo;

        public HerbsController(IHerbRepository herbRepo)
        {
            _herbRepo = herbRepo;
        }

        // GET: Herbs
        public async Task<IActionResult> Index()
        {
            return View(_herbRepo.GetAll());
        }

        // GET: Herbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var herbs = _herbRepo.Find(id.GetValueOrDefault());
               
            if (herbs == null)
            {
                return NotFound();
            }

            return View(herbs);
        }

        // GET: Herbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Herbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HerbId,Name,Info,Healing")] Herbs herbs)
        {
            if (ModelState.IsValid)
            {
                _herbRepo.Add(herbs);
                return RedirectToAction(nameof(Index));
            }
            return View(herbs);
        }

        // GET: Herbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var herbs = _herbRepo.Find(id.GetValueOrDefault());
            if (herbs == null)
            {
                return NotFound();
            }
            return View(herbs);
        }

        // POST: Herbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HerbId,Name,Info,Healing")] Herbs herbs)
        {
            if (id != herbs.HerbId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _herbRepo.Update(herbs);
                return RedirectToAction(nameof(Index));
            }
            return View(herbs);
        }

        // GET: Herbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _herbRepo.Remove(id.GetValueOrDefault());
            return RedirectToAction(nameof(Index));
        }       
    }
}
