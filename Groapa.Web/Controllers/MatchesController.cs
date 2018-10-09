using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Groapa.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.OData.Query.SemanticAst;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers.Web
{
    public class MatchesController : Controller
    {
        public IActionResult Index(int round = 1)
        {
            var model = new MatchesViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Read(string SelectedRound)
        {
            return RedirectToAction("Index", new { round = int.Parse(SelectedRound) });
        }
    }
}