using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BulkyBookVSC.Models;

namespace BulkyBookVSC;

public class CategoryController: Controller
{
  public IActionResult Index ()
  {
    return View();
  }
}
