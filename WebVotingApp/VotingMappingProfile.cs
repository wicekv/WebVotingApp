using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVotingApp.Entities;
using WebVotingApp.Models;

namespace WebVotingApp
{
    public class VotingMappingProfile : Profile
    {

        public VotingMappingProfile()
        {
            CreateMap<CreateVoterDto, Voter>();
            CreateMap<CreateCandidateDto, Candidate>();

            CreateMap<Candidate, CandidateDto>();
            CreateMap<Voter, VoterDto>();

        }
    }
}
