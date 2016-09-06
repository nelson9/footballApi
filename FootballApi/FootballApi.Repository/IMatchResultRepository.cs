using FootballApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApi.Repository
{
    public interface IMatchResultRepository
    {
        int InsertMatchResult(MatchResult e);
        IEnumerable<MatchResult> GetGameWeek(int gameWeek);
        IEnumerable<MatchResult> GetMatchResults();


    }
}
