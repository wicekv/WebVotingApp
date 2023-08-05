using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVotingApp.Models
{
    public class VoteDto
    {
        public int CandidateId { get; set; }
        public int VoterId { get; set; }
    }
}
