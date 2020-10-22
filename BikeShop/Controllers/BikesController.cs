using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BikeShop.Models;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices.ComTypes;

namespace BikeShop.Controllers
{
    public class BikesController : Controller
    {
        private readonly AdventureWorksLT2017Context db;

        public BikesController(AdventureWorksLT2017Context context)
        {
            db = context;
        }

        // GET: Bikes
        //public async Task<IActionResult> Index()
        //{
        //    var adventureWorksLT2017Context = _context.ProductCategory.Include(p => p.ParentProductCategory);
        //    return View(await adventureWorksLT2017Context.ToListAsync());
        //}

        public IActionResult Index()
        {
            var bikeList = from bikes in db.ProductCategory
                           where bikes.ParentProductCategoryId == 1
                           select bikes;



            return View(bikeList.ToList());
        }

        public IActionResult Touring()
        {
            var validTouringProducts = (from bikes in db.VProductAndDescription
                                        where bikes.Culture == "en"
                                        && bikes.SellEndDate == null
                                        && bikes.ProductCategoryId == 7
                                        select new BikeListModel
                                        {
                                            ProductModel = bikes.ProductModel,
                                            Description = bikes.Description,
                                            ProductModelID = bikes.ProductModelId
                                        }).Distinct().ToList();
            
            return View(validTouringProducts);
        }

        public IActionResult Mountain()
        {
            var validMountainProducts = (from bikes in db.VProductAndDescription
                                         where bikes.Culture == "en"
                                         && bikes.SellEndDate == null
                                         && bikes.ProductCategoryId == 5
                                         select new BikeListModel
                                         {
                                            ProductModel = bikes.ProductModel,
                                            Description = bikes.Description,
                                            ProductModelID = bikes.ProductModelId
                                         }).Distinct().ToList();

            return View(validMountainProducts);
        }

        public IActionResult Road()
        {
            var validRoadProducts = (from bikes in db.VProductAndDescription
                                     where bikes.Culture == "en"
                                     && bikes.SellEndDate == null
                                     && bikes.ProductCategoryId == 6
                                     select new BikeListModel
                                     {
                                         ProductModel = bikes.ProductModel,
                                         Description = bikes.Description,
                                         ProductModelID = bikes.ProductModelId
                                     }).Distinct().ToList();

            return View(validRoadProducts);
        }

        // GET: Bikes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = from product in db.Product
                           where product.ProductModelId == id && product.SellEndDate == null
                           select product;

            if (products == null)
            {
                return NotFound();
            }

            return View(products.ToList());
        }

        // GET: Bikes/Create
        public IActionResult Create()
        {
            ViewData["ParentProductCategoryId"] = new SelectList(db.ProductCategory, "ProductCategoryId", "Name");
            return View();
        }

        // POST: Bikes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductCategoryId,ParentProductCategoryId,Name,Rowguid,ModifiedDate")] ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                db.Add(productCategory);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentProductCategoryId"] = new SelectList(db.ProductCategory, "ProductCategoryId", "Name", productCategory.ParentProductCategoryId);
            return View(productCategory);
        }

        // GET: Bikes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await db.ProductCategory.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            ViewData["ParentProductCategoryId"] = new SelectList(db.ProductCategory, "ProductCategoryId", "Name", productCategory.ParentProductCategoryId);
            return View(productCategory);
        }

        // POST: Bikes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductCategoryId,ParentProductCategoryId,Name,Rowguid,ModifiedDate")] ProductCategory productCategory)
        {
            if (id != productCategory.ProductCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(productCategory);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCategoryExists(productCategory.ProductCategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentProductCategoryId"] = new SelectList(db.ProductCategory, "ProductCategoryId", "Name", productCategory.ParentProductCategoryId);
            return View(productCategory);
        }

        // GET: Bikes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await db.ProductCategory
                .Include(p => p.ParentProductCategory)
                .FirstOrDefaultAsync(m => m.ProductCategoryId == id);
            if (productCategory == null)
            {
                return NotFound();
            }

            return View(productCategory);
        }

        // POST: Bikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productCategory = await db.ProductCategory.FindAsync(id);
            db.ProductCategory.Remove(productCategory);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductCategoryExists(int id)
        {
            return db.ProductCategory.Any(e => e.ProductCategoryId == id);
        }
    }
}
