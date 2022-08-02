using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UrnaEletrônica.Dto;
using UrnaEletrônica.Models;

namespace UrnaEletrônica.Services
{
    public class VoteService
    {
        public void InsertVote(Vote vote)
        {
            vote.Data = DateTime.Now;
            HubCountContext.Votes.Add(vote);
            HubCountContext.SaveChanges();
            


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
            return lista;
        }
        public VoteService(HubCountContext context)
        {
            HubCountContext = context;
        }
        private HubCountContext HubCountContext { get; set; }
    }
}
