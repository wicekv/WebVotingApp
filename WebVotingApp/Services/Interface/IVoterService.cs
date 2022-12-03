using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVotingApp.Models;

namespace WebVotingApp.Services.Interface
{
    public interface IVoterService
    {
        public void CreateVoter(CreateVoterDto createVoter);
        public List<VoterDto> GetVoters();
        public void VoteForTheCandidate(VoteDto voteDto);
    }
}
