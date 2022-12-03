using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVotingApp.Entities
{
    public class Voter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasVoted { get; set; }

        public Voter(string Name)
        {
            this.Name = Name;
            this.HasVoted = false;
        }

        public void ChangeHasVoted(bool HasVoted)
        {
            this.HasVoted = HasVoted;
        }

    }
}
