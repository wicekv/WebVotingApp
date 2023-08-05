using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVotingApp.Models;

namespace WebVotingApp.Services.Interface
{
    public interface ICandidateService
    {
        public List<CandidateDto> GetCandidates();
        public void CreateCandidate(CreateCandidateDto createCandidate);
    }
}
