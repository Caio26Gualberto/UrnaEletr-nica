using System.ComponentModel.DataAnnotations;

namespace UrnaEletrônica.Dto
{
    public class InsertCandidateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ViceName { get; set; }
    }
}
