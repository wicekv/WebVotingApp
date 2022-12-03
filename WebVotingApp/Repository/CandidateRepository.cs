using System.Collections.Generic;
using System.Linq;
using WebVotingApp.Entities;
using WebVotingApp.Repository.Interface;

namespace WebVotingApp.Repository
{
    
    public class CandidateRepository : ICandidateRepository
    {
        private readonly VotingDbContext _context;

        public CandidateRepository(VotingDbContext context)
        {
            _context = context;
        }

        public void Create(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            _context.SaveChanges();
        }
        public IEnumerable<Candidate> GetCandidates()
        {
            return _context.Candidates;
        }
        public Candidate GetCandidate(int id)
        {
            return _context.Candidates.Where(c => c.Id == id).FirstOrDefault();
        }
        public void Update(Candidate candidate)
        {
            _context.Candidates.Update(candidate);
            _context.SaveChanges();
        }
    }
}
