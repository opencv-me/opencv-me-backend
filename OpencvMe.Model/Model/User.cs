﻿using OpencvMe.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpencvMe.Model.Model
{
    public class User:BaseModel
    {

        [Key]
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string IsMale { get; set; }
        public string Password { get; set; }
        public string Language { get; set; }
    }
}
