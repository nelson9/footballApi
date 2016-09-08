using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FootballApi.Data.Generic;

namespace FootballApi.Data.Repositories
{
    public class MatchResultRepository : Repository<Match>
    {
        public FootballLeaugeContext FootballLeaugeContext
        {
            get
            {
                return Context as FootballLeaugeContext;
            }
        }

        public MatchResultRepository(FootballLeaugeContext context) : base(context)
        {
            
        }
    }
}
