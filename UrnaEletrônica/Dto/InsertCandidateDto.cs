using System;
using System.ComponentModel.DataAnnotations;

namespace UrnaEletrônica.Dto
{
    public class InsertCandidateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ViceName { get; set; }
        [Required]
        public Int32 Subject { get; set; }
    }
}
