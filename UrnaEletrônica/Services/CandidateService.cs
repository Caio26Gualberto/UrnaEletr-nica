using System;
using System.Linq;
using UrnaEletrônica.Models;

namespace UrnaEletrônica.Services
{
    public class CandidateService
    {
        public void InsertCandidate(Candidate candidate)
        {
            candidate.RegistrationData = DateTime.Now;
            HubCountContext.Candidates.Add(candidate);
            HubCountContext.SaveChanges();
        }
        public CandidateService(HubCountContext context, VoteService voteService)
        {
            HubCountContext = context;
            VoteService = voteService;
        }
        private HubCountContext HubCountContext { get; set; }
        private VoteService VoteService { get; set; }
        public void DeleteCandidate(int subject)
        {
            VoteService.DeleteVotes(subject);
            var candidateDelete = HubCountContext.Candidates.FirstOrDefault(item => item.Subject == subject );
            HubCountContext.Candidates.Remove(candidateDelete);
            HubCountContext.SaveChanges();
        }

        public Candidate GetCandidate(int subject)
        {
            return HubCountContext.Candidates.FirstOrDefault(item => item.Subject == subject);
        }
    }
}
