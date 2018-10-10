using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Groapa.Domain.Data;
using Groapa.Domain.DataService;
using Groapa.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.OData.Query.SemanticAst;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers.Web
{
    public class MatchesController : Controller
    {
        private readonly IMatchesRepository matchesRepository;

        public MatchesController(IMatchesRepository matchesRepository)
        {
            this.matchesRepository = matchesRepository;
        }

        [Authorize]
        public IActionResult Index(int round = 1)
        {
            var model = new MatchesViewModel();
            model.Matches = matchesRepository.GetRoundMathes(round);
            model.RoundSelectList = Constants.Round.Select(x => new SelectListItem { Value = x.ToString(), Text = x.ToString() }).ToList();
            model.SelectedRound = round;
            return View(model);
        }

        [HttpPost]
        public IActionResult Read(string SelectedRound)
        {
            return RedirectToAction("Index", new { round = int.Parse(SelectedRound) });
        }
    }
}