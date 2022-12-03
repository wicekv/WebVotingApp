using System.Collections.Generic;
using WebVotingApp.Entities;

namespace WebVotingApp.Repository.Interface
{
    public interface IVoterRepository
    {
        public void Create(Voter voter);
        public IEnumerable<Voter> GetVoters();
        public Voter GetVoter(int id);
        public void Update(Voter voter);

    }
}
