using Groapa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Groapa.Domain.DataService
{
    public class MatchesRepository : IMatchesRepository
    {
        private readonly GroapaContext groapaContext;

        public MatchesRepository(GroapaContext groapaContext)
        {
            this.groapaContext = groapaContext;
        }

        public IQueryable<MatchSqlView> GetRoundMathes(int round)
        {
            return groapaContext.Matches.Where(x => x.Round == round);
        }


    }
}
