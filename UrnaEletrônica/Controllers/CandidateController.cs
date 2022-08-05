using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrnaEletrônica.Dto;
using UrnaEletrônica.Models;
using UrnaEletrônica.Services;

namespace UrnaEletrônica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private CandidateService candidateServices { get; set; }
        public CandidateController(CandidateService services)
        {
            candidateServices = services;
        }
        [HttpPost("candidate")]
        public IActionResult InsertCandidate(InsertCandidateDto Dto)
        {
            Candidate candidate = new Candidate();
            candidate.Name = Dto.Name;
            candidate.ViceName = Dto.ViceName;
            candidate.Subject = Dto.Subject;
            candidateServices.InsertCandidate(candidate);


            return Ok();
        }
        [HttpDelete("candidate/{subject}")]
        public IActionResult DeleteCandidate(int subject)
        {
            candidateServices.DeleteCandidate(subject);
            return Ok();
        }

        [HttpGet("candidate/{subject}")]
        public IActionResult GetCandidate(int subject)
        {
            var candidate = candidateServices.GetCandidate(subject);
            if (candidate == null) return NotFound();
            return Ok(candidate);
        }

    }
}
