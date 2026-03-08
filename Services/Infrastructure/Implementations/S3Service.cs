using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;

namespace StageWise.Services.Infrastructure.Implementations
{
    public class S3Service : IS3Service
    {
        private readonly IAmazonS3 _s3;
        private readonly string _bucketName;

        public S3Service(IConfiguration configuration)
        {
            var accessKey = configuration["AWS:AccessKey"];
            var secretKey = configuration["AWS:SecretKey"];
            var region = configuration["AWS:Region"];
            _bucketName = configuration["AWS:BucketName"]!;

            var config = new AmazonS3Config
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName(region)
            };

            _s3 = new AmazonS3Client(accessKey, secretKey, config);
        }

        public async Task UploadBytesAsync(byte[] fileBytes, string key, string contentType)
        {
            using var stream = new MemoryStream(fileBytes);

            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = stream,
                Key = key,
                BucketName = _bucketName,
                ContentType = contentType
            };

            var transferUtility = new TransferUtility(_s3);

            await transferUtility.UploadAsync(uploadRequest);

        }
    }
}