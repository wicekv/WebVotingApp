using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVotingApp.Models;
using WebVotingApp.Services;

namespace WebVotingApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class CandidatesController: ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [Route("create/candidate")]
        [HttpPost]
        public ActionResult CreateCandidate([FromBody] CreateCandidateDto candidateDto)
        {
            _candidateService.CreateCandidate(candidateDto);
            return Ok();
        }
        [Route("candidates")]
        [HttpGet]
        public ActionResult<List<VoterDto>> Get()
        {
            return Ok(_candidateService.GetCandidates());
        }
    }
}
