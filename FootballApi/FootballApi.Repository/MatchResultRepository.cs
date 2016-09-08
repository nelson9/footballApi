using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballApi.Models;
using FootballApi.Models.Enums;

namespace FootballApi.Repository
{
    public class MatchResultRepository : IMatchResultRepository
    {
        public IEnumerable<MatchResult> GetGameWeek(int gameWeek)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MatchResult> GetMatchResults()
        {
           var matchResults = new List<MatchResult>()
           {
               new MatchResult
               {
                   //AwayGoals = 3,
                   //HomeGoals = 2,
                   //AwayTeam = new Team
                   //{
                   //    Name = "Arsnel",
                   //},
                   //HomeTeam= new Team
                   //{
                   //    Name = "Rangers"
                   //},
                   //GameWeek = 1,
                   //Result = Result.AwayWin

               },
                new MatchResult
               {
                   //AwayGoals = 2,
                   //HomeGoals = 3,
                   //AwayTeam = new Team
                   //{
                   //    Name = "Chelsea",
                   //},
                   //HomeTeam= new Team
                   //{
                   //    Name = "Aberdeen"
                   //},
                   //GameWeek = 1,
                   //Result = Result.HomwWin


               },
                new MatchResult
               {
                   //AwayGoals = 2,
                   //HomeGoals = 2,
                   //AwayTeam = new Team
                   //{
                   //    Name = "Aberdeen"
                   //},
                   //HomeTeam= new Team
                   //{
                   //    Name = "Chelsea",
                      
                   //},
                   //GameWeek = 1,
                   //Result = Result.Draw


               },

           };
            return matchResults;
        }

        public int InsertMatchResult(MatchResult e)
        {
            throw new NotImplementedException();
        }
    }
}
