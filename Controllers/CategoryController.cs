﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BulkyBookVSC.Models;

namespace BulkyBookVSC;

public class CategoryController : Controller
{
  private readonly ApplicationDbContext _db;

  public CategoryController(ApplicationDbContext db)
  {
    _db = db;

  }
  public IActionResult Index()
  {
    IEnumerable<Category> objCategoryList = _db.Categories;
    return View(objCategoryList);
  }

  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult Create(Category obj)
  {
    if (obj.Name == obj.DisplayOrder.ToString())
    {
      ModelState.AddModelError("name", "The Display Order cannot be the same as the Name.");
    }
    if (ModelState.IsValid)
    {
      _db.Categories.Add(obj);
      _db.SaveChanges();
      TempData["success"] = "Category has been successfully created.";
      return RedirectToAction("Index");
    }
    return View(obj);
  }

  public IActionResult Edit(int? id)
  {
    if (id == null || id == 0)
    {
      return NotFound();
    }

    var categoryFromDb = _db.Categories.Find(id);

    if (categoryFromDb == null)
    {
      return NotFound();
    }

    return View(categoryFromDb);
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult Edit(Category obj)
  {
    if (obj.Name == obj.DisplayOrder.ToString())
    {
      ModelState.AddModelError("name", "The Display Order cannot be the same as the Name.");
    }
    if (ModelState.IsValid)
    {
      _db.Categories.Update(obj);
      _db.SaveChanges();
      TempData["success"] = "Category has been successfully updated.";

      return RedirectToAction("Index");
    }
    return View(obj);
  }

  public IActionResult Delete(int? id)
  {
    if (id == null || id == 0)
    {
      return NotFound();
    }

    var categoryFromDb = _db.Categories.Find(id);

    if (categoryFromDb == null)
    {
      return NotFound();
    }

    return View(categoryFromDb);
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult DeletePost(int? id)
  {
    var obj = _db.Categories.Find(id);

    if (obj == null)
    {
      return NotFound();
    }

    _db.Categories.Remove(obj);
    _db.SaveChanges();
    TempData["success"] = "Category has been successfully Deleted.";

    return RedirectToAction("Index");

  }
}
