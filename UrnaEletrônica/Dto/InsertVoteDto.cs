using System.ComponentModel.DataAnnotations;

namespace UrnaEletrônica.Dto
{
    public class InsertVoteDto
    {
        [Required]
        public int Subject { get; set; }
    }
}
