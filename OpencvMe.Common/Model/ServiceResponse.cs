using System;
using System.Collections.Generic;
using System.Text;

namespace OpencvMe.Common.Model
{
    public class ServiceResponse <T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public ServiceResponse<T> Success(string message = "İşlem Başarılı")
        {
            this.IsSuccess = true;
            this.Message = message;

            return this;
        }

        public ServiceResponse<T> Error(string message = "İşlem Hatalı")
        {
            this.IsSuccess = true;
            this.Message = message;

            return this;
        }
    }
}
