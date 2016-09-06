using FootballApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApi.DTO
{
    public interface IMatchResultDTOFactory
    {
        MatchResultDTO CreateMatchResultDto(MatchResult matchResult);
    }

    public class MatchResultDTOFactory : IMatchResultDTOFactory
    {
        public MatchResultDTO CreateMatchResultDto(MatchResult matchResult)
        {
            return new MatchResultDTO()
            {
                AwayGoals = matchResult.AwayGoals,
                AwayTeam = matchResult.AwayTeam.Name,
                GameWeek = matchResult.GameWeek, 
                HomeGoals = matchResult.HomeGoals,
                HomeTeam = matchResult.HomeTeam.Name,
                Result = GetResult(matchResult)                
            };
        }

        private string GetResult(MatchResult matchResult)
        {
            if (matchResult.AwayGoals > matchResult.HomeGoals)
            {
                return "Away win";
            }
            else if (matchResult.AwayGoals < matchResult.HomeGoals)
            {
                return "Home Win";
            }
            else
            {
                return "Draw";
            }
        }
    }
}
