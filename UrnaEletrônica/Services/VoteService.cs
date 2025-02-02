﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UrnaEletrônica.Dto;
using UrnaEletrônica.Models;

namespace UrnaEletrônica.Services
{
    public class VoteService
    {
        public void InsertVote(int subject)
        {
            Vote vote = new Vote();
            if (subject != 0)
            {
                var candidate = HubCountContext.Candidates.FirstOrDefault(candidate => candidate.Subject == subject);
                if (candidate == null)
                {
                    throw new Exception("Candidato informado não existe");
                }
                vote.CandidateId = candidate.CandidateId;
            }
            
            vote.Data = DateTime.Now;
            HubCountContext.Votes.Add(vote);
            HubCountContext.SaveChanges();
            


        }
        public void DeleteVotes (int subject)
        {
            if (subject != 0)
            {
                var candidate = HubCountContext.Candidates.FirstOrDefault(candidate => candidate.Subject == subject);
                if (candidate == null)
                {
                    throw new Exception("Candidato informado não existe");
                }
               var votesCandidate = HubCountContext.Votes.Where(vote => vote.CandidateId == candidate.CandidateId);
                foreach (var vote in votesCandidate)
                {
                    HubCountContext.Votes.Remove(vote);
                }
                HubCountContext.SaveChanges();
            }
        }

        public List<GetVotesByCandidateDto> GetVotes()
        {
            var votes = HubCountContext.Candidates.Include(candidate => candidate.Votes).ToList();
            List<GetVotesByCandidateDto> lista = new List<GetVotesByCandidateDto>();
            foreach (var vote in votes)
            {
                var dto = new GetVotesByCandidateDto();
                dto.Name = vote.Name;
                dto.ViceName = vote.ViceName;
                dto.Subject = vote.Subject;
                dto.TotalVotes = vote.Votes.Count();
                lista.Add(dto);
            }
            return lista.OrderByDescending(o => o.TotalVotes).ToList();
        }
        public VoteService(HubCountContext context)
        {
            HubCountContext = context;
        }
        private HubCountContext HubCountContext { get; set; }
    }
}
