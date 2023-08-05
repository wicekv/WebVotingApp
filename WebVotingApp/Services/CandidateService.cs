using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebVotingApp.Entities;
using WebVotingApp.Models;
using WebVotingApp.Repository.Interface;
using WebVotingApp.Services.Interface;

namespace WebVotingApp.Services
{
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
            Candidate candidate = new Candidate(createCandidate.Name);

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
