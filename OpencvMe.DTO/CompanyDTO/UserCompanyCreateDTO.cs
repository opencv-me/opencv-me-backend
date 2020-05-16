using System;
using System.Collections.Generic;
using System.Text;

namespace OpencvMe.DTO.CompanyDTO
{
    public class UserCompanyCreateDTO
    {
        public int UserCompanyId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string Position { get; set; }

        public bool IsWorking { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string Description { get; set; }
    }
}
