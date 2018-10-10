using System.Linq;
using Groapa.Domain.Models;

namespace Groapa.Domain.DataService
{
    public interface IMatchesRepository
    {
        IQueryable<MatchSqlView> GetRoundMathes(int round);
    }
}