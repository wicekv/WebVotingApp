using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVotingApp.Models
{
    public class VoterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasVoted { get; set; }
    }
}
