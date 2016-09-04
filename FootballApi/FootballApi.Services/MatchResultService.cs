using FootballApi.Models;
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
    }

    public class MatchResultService : IMatchResultService
    {
        private readonly ICsvReader _csvReader;

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

        //public IEnumerable<TableResult> CreateLeagueTable()
        //{
        //    var results = GetMatchResultsFromCsv(@"C:\Users\Niall\Documents\GitHub\footballApi\FootballApi\FootballApi\input.csv");

        //    return matchResults;
        //}

    }
}
