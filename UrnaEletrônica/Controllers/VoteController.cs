using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrnaEletrônica.Dto;
using UrnaEletrônica.Models;
using UrnaEletrônica.Services;

namespace UrnaEletrônica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        public VoteService VoteService { get; set; }
        public VoteController(VoteService voteService)
        {
            VoteService = voteService;
        }
        [HttpPost("vote")]
        public IActionResult InsertVote(InsertVoteDto insertVote)
        {
            try
            {
                VoteService.InsertVote(insertVote.Subject);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
            
        }
        [HttpGet("votes")]
        public IActionResult GetVotes()
        {
            var votes = VoteService.GetVotes();
            return Ok(votes);
        }
    }
}
