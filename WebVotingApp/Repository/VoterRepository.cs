using System.Collections.Generic;
using System.Linq;
using WebVotingApp.Entities;
using WebVotingApp.Repository.Interface;

namespace WebVotingApp.Repository
{
    public class VoterRepository: IVoterRepository
    {
        private readonly VotingDbContext _context;

        public VoterRepository(VotingDbContext context)
        {
            _context = context;
        }
        public void Create(Voter voter)
        {
            _context.Voters.Add(voter);
            _context.SaveChanges();
        }
        public IEnumerable<Voter> GetVoters()
        {
            return _context.Voters;
        }
        public Voter GetVoter(int id)
        {
            return _context.Voters.Where(v => v.Id == id).FirstOrDefault();
        }
        public void Update(Voter voter)
        {
            _context.Voters.Update(voter);
            _context.SaveChanges();
        }
    }
}
