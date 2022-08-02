using System;

namespace UrnaEletrônica.Dto
{
    public class GetVotesByCandidateDto
    {
        public string Name { get; set; }

        public string ViceName { get; set; }
        public Int32 Subject { get; set; }
        public int TotalVotes { get; set; }
    }
}
