using FootballApi.DTO;
using FootballApi.Models;
using FootballApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FootballApi.Controllers
{
    public class MatchResultController : ApiController
    {
        private readonly IMatchResultService _matchResultService;
        private readonly IMatchResultDTOFactory _matchResultDTOFactory;
        public MatchResultController(IMatchResultService matchResultService, IMatchResultDTOFactory matchResultDTOFactory)
        {
            _matchResultService = matchResultService;
            _matchResultDTOFactory = matchResultDTOFactory;
        }

        [HttpGet]
        [Route("api/results/{id:int:range(1,38)}")]
        public IHttpActionResult Result(int id)
        {
            try
            {
                var matchResults = _matchResultService.GetMatchResultsFromCsv(@"C:\Users\Niall\Documents\GitHub\footballApi\FootballApi\FootballApi\input.csv");
                return Ok(matchResults.Select(x => _matchResultDTOFactory.CreateMatchResultDto(x)).Where(x => x.GameWeek == id).OrderBy(x => x.HomeTeam));            
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/results/", Name = "Results")]
        public IHttpActionResult Result([FromBody]MatchResult matchResult)
        {
            try
            {
                if (matchResult == null)
                {
                    return BadRequest();
                }

                matchResult.Result = _matchResultService.GetResult(matchResult);

                return CreatedAtRoute("Results", new { controller = "", id = matchResult.Id }, matchResult);
            }
            catch (Exception)
            {
                return InternalServerError();
            }            
        }

        [HttpGet]
        [Route("api/table/")]
        public IHttpActionResult Table()
        {
            try
            {
                var matchResults = _matchResultService.GetMatchResultsFromCsv(@"C:\Users\Niall\Documents\GitHub\footballApi\FootballApi\FootballApi\input.csv");                
                return Ok(matchResults);               
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

    }
}
