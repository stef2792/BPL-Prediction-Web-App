
using Groapa.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Groapa.Domain.Models
{
    public class MatchesViewModel
    {
        public int SelectedRound { get; set; }
        public List<SelectListItem> RoundSelectList { get; set; }
        public IEnumerable<MatchViewModel> Matches { get; set; }
    }
}
