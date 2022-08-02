using System;
using System.Text.Json.Serialization;

namespace UrnaEletrônica.Models
{
    public class Vote
    {
        public int VoteId { get; set; }

        public DateTime Data { get; set; }

        public int CandidateId { get; set; }
        [JsonIgnore]
        public virtual Candidate Candidate { get; set; }
    }
}
