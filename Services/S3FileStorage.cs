
using Amazon.S3;
using Amazon.S3.Model;
using System.Security.AccessControl;

namespace WebAPI.Services
{
    public class S3FileStorage : IFileStorage
    {
        private readonly IAmazonS3 _S3Client;
        private readonly ILogger _logger;
        private readonly string _BucketName = "tb-aspnet-bucket";
        public S3FileStorage(ILogger<S3FileStorage> logger, IAmazonS3 client, IConfiguration config) 
        { 
            _logger = logger;
            _S3Client = client;
        }
        public async Task<bool> SaveFileAsync(string FilePath, string FileName)
        {
            var request = new PutObjectRequest
            {
                BucketName = _BucketName,
                Key = FileName,
                FilePath = FilePath,
            };

            var response = await _S3Client.PutObjectAsync(request);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                throw new Exception(FileName + " could not be saved");
            }
        }

        public async Task<bool> DeleteFileAsync(string FileName)
        {
            try
            {
                var deleteObjectRequest = new DeleteObjectRequest
                {
                    BucketName = _BucketName,
                    Key = FileName,
                };

                await _S3Client.DeleteObjectAsync(deleteObjectRequest);

                return true;
            }
            catch (AmazonS3Exception e)
            {
                throw new Exception($"Failed to delete {FileName}");
            }
        }
    }
}
