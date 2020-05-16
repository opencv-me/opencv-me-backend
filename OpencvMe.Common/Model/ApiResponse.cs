using System;
using System.Collections.Generic;
using System.Text;

namespace OpencvMe.Common.Model
{
   public class ApiResponse<T>
    {


        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string  Message { get; set; }
        public int StatusCode { get; set; }

        public ApiResponse<T> Success(string message = "İşlem Başarılı")
        {
            this.IsSuccess = true;
            this.Message = message;

            return this;
        }

        public ApiResponse<T> Error(string message = "İşlem Hatalı")
        {
            this.IsSuccess = false;
            this.Message = message;
            return this;
        }
    }
}
