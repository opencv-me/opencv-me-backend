using OpencvMe.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpencvMe.Model.Model
{
   public class UserCompany : BaseModel
    {
        [Key]
        public int UserCompanyId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }


        /// <summary>
        /// Hala Çalışıyor mu
        /// </summary>
        public bool IsWorking { get; set; }
        /// <summary>
        /// İşe Başlama Tarihi
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// İşten Çıkış Tarihi
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Çalıtığı Pozisypn
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// İş Hakında Açıklama
        /// </summary>
        public string Description { get; set; }

    }
}
