using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApi.Models
{
    public class Team
    {
        public int Id { get; set; }
        public virtual ICollection<MatchResult> HomeResults { get; set; }
        public virtual ICollection<MatchResult> AwayResults { get; set; }

    }
}
