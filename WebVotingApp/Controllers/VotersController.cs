using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebVotingApp.Models;
using WebVotingApp.Services.Interface;

namespace WebVotingApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class VotersController: ControllerBase
    {
        private readonly IVoterService _voterService;

        public VotersController(IVoterService voterService)
        {
            _voterService = voterService;
        }

        [Route("create/voter")]
        [HttpPost]
        public ActionResult CreateVoter([FromBody] CreateVoterDto voterDto)
        {
            _voterService.CreateVoter(voterDto);

            return Ok();
        }
        
        [Route("voters")]
        [HttpGet]
        public ActionResult<List<VoterDto>> GetVoters()
        {
            return Ok(_voterService.GetVoters());
        }

        [Route("vote")]
        [HttpPut]
        public ActionResult Vote([FromBody] VoteDto voteDto)
        {
            _voterService.VoteForTheCandidate(voteDto);
            return Ok();
        }

    }
}
