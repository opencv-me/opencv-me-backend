using OpencvMe.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpencvMe.Model.Model
{


    public class UserSchool : BaseModel
    {
        [Key]
        public int UserSchoolId { get; set; }
        public int UserId { get; set; }
        public int SchoolId { get; set; }

        /// <summary>
        /// Okula Başlangıç Tarihi
        /// </summary>
       public DateTime StartDate { get; set; }
        /// <summary>
        /// Okulun bitiş tarihi
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Okulu devam ediyor mu
        /// </summary>
        public bool IsContinue { get; set; }
        /// <summary>
        /// Okuduğu Bölüm
        /// </summary>
        public string Section { get; set; } 

        /// <summary>
        /// Okul Hakkında açıklama
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// lisans derecesi
        /// </summary>
        public int licenseDegree { get; set; }
    }
}
