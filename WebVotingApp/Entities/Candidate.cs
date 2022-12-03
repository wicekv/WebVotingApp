using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public void IncreaseVotes()
        {
            this.Votes += 1;
        }
    }
}
