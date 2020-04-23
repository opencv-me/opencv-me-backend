using OpencvMe.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpencvMe.Model.Model
{
    public class Company:BaseModel
    {
        [Key]
        public int CompanyId { get; set; }
        public string Name { get; set; }
    }
}
