using System;
using System.ComponentModel.DataAnnotations;

namespace OpencvMe.DTO.CvDTO
{
    public class SocialsDTO
    {

        [StringLength(200)]
        public string Facebook { get; set; }
        [StringLength(200)]
        public string Linkedin { get; set; }
        [StringLength(200)]
        public string Twitter { get; set; }
        [StringLength(200)]
        public string Instagram { get; set; }
        [StringLength(200)]
        public string Medium { get; set; }
        [StringLength(200)]
        public string Youtube { get; set; }

    }
}
