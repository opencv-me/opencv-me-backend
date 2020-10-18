using System;
using System.Collections.Generic;
using System.Text;

namespace OpencvMe.DTO.CompanyDTO
{
    public class UserCompanyDTO
    {
        public int UserCompanyId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string Position { get; set; }

        public bool IsWorking { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }


        public string CompanyName { get; set; }
        public string StartDateStr { get; set; }
        public string EndDateStr { get; set; }

    }
}
