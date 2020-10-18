using System;
using OpencvMe.Common.Model;
using OpencvMe.Service.Interface;
namespace OpencvMe.Service.Service
{
    public class UploadService : IUploadService
    {


       // private static readonly string _awsAccessKey = ConfigurationManager.AppSettings["AWSAccessKey"];
       //
       // private static readonly string _awsSecretKey = ConfigurationManager.AppSettings["AWSSecretKey"];
       //
       // private static readonly string _bucketName = ConfigurationManager.AppSettings["Bucketname"];




        public ServiceResponse<bool> UploadProfilePhoto(string base64Image)
        {
            var response = new ServiceResponse<bool>();



            return response;
        }



      // public string UploadS3 (string base64String)
      // {
      //
      //     try
      //     {
      //         IAmazonS3 client;
      //
      //         byte[] bytes = Convert.FromBase64String(base64String);
      //
      //         using (client = Amazon.AWSClientFactory.CreateAmazonS3Client(_awsAccessKey, _awsSecretKey))
      //         {
      //             var request = new PutObjectRequest
      //             {
      //                 BucketName = _bucketName,
      //                 CannedACL = S3CannedACL.PublicRead,
      //                 Key = string.Format("UPLOADS/{0}", file.FileName)
      //             };
      //             using (var ms = new MemoryStream(bytes))
      //             {
      //                 request.InputStream = ms;
      //                 client.PutObject(request);
      //             }
      //         }
      //     }
      //     catch (Exception ex)
      //     {
      //
      //
      //     }
      //     
      // }
    }
}
