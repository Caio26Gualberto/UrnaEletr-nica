using System;
using System.Collections.Generic;

namespace UrnaEletrônica.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string Name { get; set; }

        public string ViceName { get; set; }

        public DateTime RegistrationData { get; set; }

        public Int32 Subject { get; set; }
        public List<Vote> Votes { get; set; }
    }
}
