using System;
using System.Collections.Generic;
using System.Text;

namespace OpencvMe.DTO.CompanyDTO
{
    public class UserCompanyResponseDTO
    {
        public int UserCompanyId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public bool IsWorking { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string Description { get; set; }
    }
}
