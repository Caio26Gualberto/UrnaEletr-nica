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
        public CandidateService(HubCountContext context)
        {
            HubCountContext = context;
        }
        private HubCountContext HubCountContext { get; set; }
        public void DeleteCandidate(int id)
        {
            var candidateDelete = HubCountContext.Candidates.FirstOrDefault(item => item.CandidateId == id);
            HubCountContext.Candidates.Remove(candidateDelete);
            HubCountContext.SaveChanges();
        }

        public Candidate GetCandidate(int subject)
        {
            return HubCountContext.Candidates.FirstOrDefault(item => item.Subject == subject);
        }
    }
}
