using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVotingApp.Entities;

namespace WebVotingApp.Repository.Interface
{
    public interface ICandidateRepository
    {
        public void Create(Candidate candidate);
        public IEnumerable<Candidate> GetCandidates();
        public Candidate GetCandidate(int id);
        public void Update(Candidate candidate);
    }
}
