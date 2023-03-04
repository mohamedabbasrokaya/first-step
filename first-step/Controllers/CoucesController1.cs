using first_step.Data;
using first_step.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace first_step.Controllers
{
    public class CoucesController1 : Controller
    {
        private readonly ApplicationDbContext context;

        public CoucesController1(ApplicationDbContext context)
        {
            this.context = context;
        }
        #region Actions
        public IActionResult Index(string SearchValue = "")
        {
            if (string.IsNullOrEmpty(SearchValue))
            {
                var cour = context.cources.GetType();
                return View(cour);
            }
            else
            {
                var cour = context.cources.GetType();
                return View(cour);
            }

        }
        public IActionResult Details(int? id, string ViewName = "Details")
        {
            if (id == null)
                return NotFound();
            var Cource = context.cources.GetType();
            if (Cource == null)
                return NotFound();
            return View(ViewName, Cource);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.cources = context.cources.GetType();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(cource cource)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                return RedirectToAction("Index");
            }
            ViewBag.cource = context.cources.GetType();
            return View(cource);
        }
        public IActionResult Edit(int? id)
        {
            ViewBag.cource = context.cources.GetType();
            return Details(id, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, cource cource)
        {
            if (id != cource.id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.cources = context.cources.GetType();
                    return View(cource);
                }
            }
            ViewBag.cources = context.cources.GetType();
            return View(cource);

        }

        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, cource cource)
        {
            if (id != cource.id)
                return NotFound();
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(cource);
            }
        }


        #endregion




    }
}

