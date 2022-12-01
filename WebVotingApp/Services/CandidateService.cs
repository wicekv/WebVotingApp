using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVotingApp.Entities;
using WebVotingApp.Models;
using WebVotingApp.Repository;

namespace WebVotingApp.Services
{
    public interface ICandidateService
    {
        public List<CandidateDto> GetCandidates();
        public void CreateCandidate(CreateCandidateDto createCandidate);
    }
    public class CandidateService : ICandidateService
    {

        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;

        public CandidateService(ICandidateRepository candidateRepository, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        public void CreateCandidate(CreateCandidateDto createCandidate)
        {
            Candidate candidate= _mapper.Map<Candidate>(createCandidate);
            _candidateRepository.Create(candidate);
        }
        public List<CandidateDto> GetCandidates()
        {
            var candidates = _candidateRepository.GetCandidates().ToList();

            List<CandidateDto> candidateDtos = _mapper.Map<List<CandidateDto>>(candidates);

            return candidateDtos;
        }
    }
}
