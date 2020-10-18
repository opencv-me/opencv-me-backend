using System;
using OpencvMe.Common.Model;

namespace OpencvMe.Service.Interface
{
    public interface IUploadService
    {
       ServiceResponse<bool> UploadProfilePhoto(string base64Image);
    }
}
