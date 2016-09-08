using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballApi.Models.Enums;

namespace FootballApi.Models
{
    public class MatchResult
    {
        public int Id { get; set; }
        public int GameWeek { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public virtual Team HomeTeam { get; set; }
        public virtual Team AwayTeam { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public Result Result { get; set; }
    }
}
