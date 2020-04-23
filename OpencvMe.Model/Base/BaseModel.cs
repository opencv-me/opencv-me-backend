using System;
using System.Collections.Generic;
using System.Text;

namespace OpencvMe.Model.Base
{
    public class BaseModel {
        public BaseModel()
        {
            this.CreatedDate = DateTime.Now;
            this.DeletedDate = null;
            this.IsDeleted = false;
            this.IsActive = true;              
        }
        
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
