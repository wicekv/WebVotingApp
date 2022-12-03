using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebVotingApp.Models;
using WebVotingApp.Services.Interface;

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
        public ActionResult<List<VoterDto>> GetCandidates()
        {
            return Ok(_candidateService.GetCandidates());
        }
    }
}
