using FootballApi.Models;
using FootballApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApi.Services
{

    public interface IMatchResultService
    {
        IEnumerable<MatchResult> GetMatchResultsFromCsv(string filePath);
        string GetResult(MatchResult matchResult);
    }

    public class MatchResultService : IMatchResultService
    {
        private readonly ICsvReader _csvReader;
        private readonly IMatchResultRepository _machResultRepository;

        public MatchResultService(ICsvReader csvReader)
        {
            _csvReader = csvReader;
        }

        public IEnumerable<MatchResult> GetMatchResultsFromCsv(string filePath)
        {
            var lines = _csvReader.ReadDataFromCsv(filePath);

            var matchResults = lines.Select(x => x.Split(',')).Select(x => new MatchResult
            {
                GameWeek = Convert.ToInt16(x[0]),
                HomeTeam = x[1],
                AwayTeam = x[2],
                HomeGoals = Convert.ToInt16(x[3]),
                AwayGoals = Convert.ToInt16(x[4]),
            });

            return matchResults;
        }

        public Result GetResult(MatchResult matchResult)
        {
            if (matchResult.AwayGoals > matchResult.HomeGoals)
            {
                return  Result.AwayWin;
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

        public IEnumerable<MatchResult> GetGameWeekResults(int gameWeek)
        {
            return _machResultRepository.GetGameWeek(gameWeek);
        }
        public int InsertMathResult(MatchResult matchResult)
        {
            return _machResultRepository.InsertMatchResult(matchResult);
        }
        public IEnumerable<TableResult> CreateLeagueTable()
        {
            var results = _machResultRepository.GetMatchResults();
            var teamList = _machResultRepository.GetMatchResults().Select(x => x.HomeTeam).Distinct().ToList();
            var asdf = new List<TableResult>();
            foreach (var match in results)
            {

            }

            return matchResults;
        }

    }
}
