using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebVotingApp.Entities;
using WebVotingApp.Exceptions;
using WebVotingApp.Models;
using WebVotingApp.Repository.Interface;
using WebVotingApp.Services.Interface;

namespace WebVotingApp.Services
{
    public class VoterService: IVoterService
    {
        private readonly IVoterRepository _voterRepository;
        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;

        public VoterService(IVoterRepository voterRepository, ICandidateRepository candidateRepository, IMapper mapper)
        {
            _voterRepository = voterRepository;
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        public void CreateVoter(CreateVoterDto createVoter)
        {
            Voter voter = _mapper.Map<Voter>(createVoter);
            _voterRepository.Create(voter);
        }
        public List<VoterDto> GetVoters()
        {
            var voters = _voterRepository.GetVoters().ToList();
            List<VoterDto> voterDtos = _mapper.Map<List<VoterDto>>(voters);

            return voterDtos;
        }
        public void VoteForTheCandidate(VoteDto voteDto)
        {
            Voter voter = GetVoter(voteDto.VoterId);
            Candidate candidate = GetCandidate(voteDto.CandidateId);

            if (voter.HasVoted)
            {
                throw new BadRequestException("You have already voted");
            }

            ChangeToAlreadyVoted(voter);
            IncreaseTheNumberOfVotes(candidate);
        }

        private Candidate GetCandidate(int Id)
        {
            var candidate = _candidateRepository.GetCandidate(Id);
            if (candidate is null)
            {
                throw new NotFoundException("The candidate does not exist");
            }
                
            return candidate;
        }

        private Voter GetVoter(int id)
        {
            var voter = _voterRepository.GetVoter(id);
            if (voter is null)
            {
                throw new NotFoundException("The voter does not exist");

            }

            return voter;
        }

        private void ChangeToAlreadyVoted(Voter voter)
        {
            voter.ChangeHasVoted(true);
            _voterRepository.Update(voter);
        }
        private void IncreaseTheNumberOfVotes(Candidate candidate)
        {
            candidate.IncreaseVotes();
            _candidateRepository.Update(candidate);
        }

    }
}
