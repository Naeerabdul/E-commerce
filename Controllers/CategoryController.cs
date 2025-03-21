using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMVC_Project.Data;
using WebMVC_Project.Models;

namespace WebMVC_Project.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _db;

		public CategoryController(ApplicationDbContext db) 
		{
			_db = db;
		}
		// GET: CategoryController
		public IActionResult Index()
		{

			var CategoryList = _db.Categories.OrderBy(x => x.CategoryOrder).ToList();
			return View(CategoryList);
		}

		// GET: CategoryController/Create
		public IActionResult Create()
		{
			return View("CreateOrEdit", new Category());
		}

		// POST: CategoryController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Category category)
		{
			try
			{
				_db.Categories.Add(category);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: CategoryController/Edit/5
		public ActionResult Edit(int id)
		{
			var categorry = _db.Categories.FirstOrDefault(c => c.Id == id);
			if (categorry == null) return NotFound();
			return View("CreateOrEdit",categorry);
		}

		// POST: CategoryController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit( Category category)
		{
			try
			{
				_db.Categories.Update(category);
				_db.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// POST: CategoryController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id)
		{
			try
			{
				var category = _db.Categories.Find(id);
				if (category == null) return NotFound();
				_db.Categories.Remove(category);
				_db.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
