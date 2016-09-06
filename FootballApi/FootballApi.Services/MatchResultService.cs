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
        private readonly ICsvReader _csvReader;
        private readonly IMatchResultRepository _machResultRepository;

        public MatchResultService(ICsvReader csvReader, IMatchResultRepository matchResultRepository)
        {
            _csvReader = csvReader;
            _machResultRepository = matchResultRepository;
        }

        //public IEnumerable<MatchResult> GetMatchResultsFromCsv(string filePath)
        //{
        //    var lines = _csvReader.ReadDataFromCsv(filePath);

        //    var matchResults = lines.Select(x => x.Split(',')).Select(x => new MatchResult
        //    {
        //        GameWeek = Convert.ToInt16(x[0]),
        //        HomeTeam = x[1],
        //        AwayTeam = x[2],
        //        HomeGoals = Convert.ToInt16(x[3]),
        //        AwayGoals = Convert.ToInt16(x[4]),
        //    });

        //    return matchResults;
        //}

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
            var homeTeams = matchResults.Select(x => x.HomeTeam);
            var awayTeams = matchResults.Select(x => x.AwayTeam);          

            var teams = homeTeams.Concat(awayTeams).DistinctBy(x => x.Name);
           
            var tablResult = new List<TableResult>();

            foreach(var team in teams)
            {
                var games = matchResults.Where(x => x.HomeTeam.Name == team.Name | x.AwayTeam.Name == team.Name);

                var gameswon = games.Count(x => x.Result == Result.AwayWin || x.Result == Result.HomwWin);
                var gamesdraw = games.Count(x => x.Result == Result.Draw);
                var gameslost = games.Count() - gameswon- gamesdraw;                
                var points = (3 * gameswon) + (gamesdraw);
                var goalsFor = matchResults.Where(x => x.HomeTeam.Name == team.Name).Sum(x => x.HomeGoals) + matchResults.Where(x => x.AwayTeam.Name == team.Name).Sum(x => x.AwayGoals);
                var goalsAgainst = matchResults.Where(x => x.HomeTeam.Name == team.Name).Sum(x => x.AwayGoals) + matchResults.Where(x => x.AwayTeam.Name == team.Name).Sum(x => x.HomeGoals);
                var goalDiffernce = goalsFor - goalsAgainst;

                var tableResult = new TableResult
                {
                    Team = team.Name,
                    GamesLost = gameslost,
                    GamesWon = gameswon,
                    GamesPlayed = gameswon + gameslost + gamesdraw,
                    Points = points,       
                    GoalsFor = goalsFor,
                    GoalsAgainst = goalsAgainst,
                    GoalDifference = goalDiffernce        

                };
                tablResult.Add(tableResult);
            }
            int i = 1;
            var asdf = tablResult.OrderBy(x => x.GamesWon).ThenByDescending(x => x.Points).ThenByDescending(x => x.GoalDifference);

            foreach (var a in asdf)
            {
                a.Position = i;
                i++;
            }
            return tablResult.OrderBy(x => x.Position);
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
