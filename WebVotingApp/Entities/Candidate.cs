using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVotingApp.Entities
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Votes { get; set; }

        public Candidate(string Name)
        {
            this.Name = Name;
            this.Votes = 0;
        }
    }
}
