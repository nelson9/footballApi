using FootballApi.Models;
using FootballApi.Repository;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FootballApi.Services
{

    public interface IMatchResultService
    {
        //IEnumerable<MatchResult> GetMatchResultsFromCsv(string filePath);
        //string GetResult(MatchResult matchResult);
        string SaveResult(MatchResult matchResult);
        IEnumerable<MatchResult> GetMatchResults();
        IEnumerable<TableResult> GetTable();
    }

    public class MatchResultService : IMatchResultService
    {     
        private readonly IMatchResultRepository _machResultRepository;

        public MatchResultService(ICsvReader csvReader, IMatchResultRepository matchResultRepository)
        {
           _machResultRepository = matchResultRepository;
        }

        public void SaveResult(MatchResult matchResult)
        {
            matchResult.Result = SetResult(matchResult);
        }

        public IEnumerable<MatchResult> GetGameWeekResults(int gameWeek)
        {
            return _machResultRepository.GetGameWeek(gameWeek);
        }
        public int InsertMatchResult(MatchResult matchResult)
        {
            return _machResultRepository.InsertMatchResult(matchResult);
        }

        public IEnumerable<MatchResult> GetMatchResults()
        {
            return _machResultRepository.GetMatchResults();
        }

        public IEnumerable<TableResult> GetTable()
        {

            var matchResults = _machResultRepository.GetMatchResults();
            var teams = matchResults.Select(x => x.HomeTeam).Union(matchResults.Select(x => x.AwayTeam)).DistinctBy(x => x.Name);
       
            var tablResult = new List<TableResult>();

            foreach(var team in teams)
            {
                tablResult.Add(CreateTable(matchResults, team));
            }
                        
            return RankTeam(tablResult).OrderBy(x => x.Position);
        }

        private IEnumerable<TableResult> RankTeam(List<TableResult> tableResult)
        {
            int i = 1;
            var orderedResult = tableResult.OrderBy(x => x.GamesWon).ThenByDescending(x => x.Points).ThenByDescending(x => x.GoalDifference);

            foreach (var a in orderedResult)
            {
                a.Position = i;
                i++;
            }

            return orderedResult;
        }
    

        private TableResult CreateTable(IEnumerable<MatchResult> matchResults, Team team)
        {
            var games = matchResults.Where(x => x.HomeTeam.Name == team.Name | x.AwayTeam.Name == team.Name);

            var gameswon = games.Count(x => x.Result == Result.AwayWin || x.Result == Result.HomwWin);
            var gamesdraw = games.Count(x => x.Result == Result.Draw);
            var gameslost = games.Count() - gameswon - gamesdraw;
            var points = (3 * gameswon) + (gamesdraw);
            var goalsFor = matchResults.Where(x => x.HomeTeam.Name == team.Name).Sum(x => x.HomeGoals) + matchResults.Where(x => x.AwayTeam.Name == team.Name).Sum(x => x.AwayGoals);
            var goalsAgainst = matchResults.Where(x => x.HomeTeam.Name == team.Name).Sum(x => x.AwayGoals) + matchResults.Where(x => x.AwayTeam.Name == team.Name).Sum(x => x.HomeGoals);
            var goalDiffernce = goalsFor - goalsAgainst;

            return new TableResult
            {
                Team = team.Name,
                GamesLost = gameslost,
                GamesWon = gameswon,
                GamesDrawn = gamesdraw,
                GamesPlayed = gameswon + gameslost + gamesdraw,
                Points = points,
                GoalsFor = goalsFor,
                GoalsAgainst = goalsAgainst,
                GoalDifference = goalDiffernce

            };

        }

        private Result SetResult(MatchResult matchResult)
        {
            if (matchResult.AwayGoals > matchResult.HomeGoals)
            {
                return Result.AwayWin;
            }
            else if (matchResult.AwayGoals < matchResult.HomeGoals)
            {
                return Result.HomwWin;
            }
            else
            {
                return Result.Draw;
            }
        }

        string IMatchResultService.SaveResult(MatchResult matchResult)
        {
            throw new NotImplementedException();
        }
    }
}
