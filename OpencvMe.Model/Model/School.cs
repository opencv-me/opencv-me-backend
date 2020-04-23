using OpencvMe.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpencvMe.Model.Model
{
    public class School:BaseModel
    {

        [Key]
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }

    }
}
