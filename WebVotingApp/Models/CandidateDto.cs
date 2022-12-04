using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVotingApp.Models
{
    public class CandidateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Votes { get; set; }
    }
}
