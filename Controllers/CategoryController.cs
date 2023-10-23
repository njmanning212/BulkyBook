using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BulkyBookVSC.Models;

namespace BulkyBookVSC;

public class CategoryController: Controller
{
  private readonly ApplicationDbContext _db;

  public CategoryController(ApplicationDbContext db)
  {
    _db = db;
    
  }
  public IActionResult Index ()
  {
    IEnumerable<Category> objCategoryList = _db.Categories;
    return View(objCategoryList);
  }

  public IActionResult Create ()
  {
    return View();
  }
}
