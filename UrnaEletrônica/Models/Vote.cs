using System;

namespace UrnaEletrônica.Models
{
    public class Vote
    {
        public int VoteId { get; set; }

        public DateTime Data { get; set; }

        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}
