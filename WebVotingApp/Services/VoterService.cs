using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVotingApp.Entities;
using WebVotingApp.Exceptions;
using WebVotingApp.Models;
using WebVotingApp.Repository;

namespace WebVotingApp.Services
{
    public interface IVoterService
    {
        public void CreateVoter(CreateVoterDto createVoter);
        public List<VoterDto> GetVoters();
        public void VoteForTheCandidate(VoteDto voteDto);
    }
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

            if (!voter.HasVoted)
            {
                ChangeToAlreadyVoted(voter);
                IncreaseTheNumberOfVotes(candidate);
            }
            else
            {
                throw new BadRequestException("You have already voted");
            }
        }

        private Candidate GetCandidate(int Id)
        {
            var candidate = _candidateRepository.GetCandidate(Id);
            if (candidate is null)
                throw new NotFoundException("The candidate does not exist");
            return candidate;
        }

        private Voter GetVoter(int id)
        {
            var voter = _voterRepository.GetVoter(id);
            if (voter is null)
                throw new NotFoundException("The voter does not exist");
            return voter;
        }

        private void ChangeToAlreadyVoted(Voter voter)
        {
            voter.HasVoted = true;
            _voterRepository.Update(voter);
        }
        private void IncreaseTheNumberOfVotes(Candidate candidate)
        {
            candidate.Votes += 1;
            _candidateRepository.Update(candidate);
        }

    }
}
