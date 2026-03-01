using Amazon.S3;
using Amazon.S3.Transfer;

namespace StageWise.Services.Infrastructure.Implementations
{
  public class S3Service : IS3Service
{
    private readonly IAmazonS3 _s3;
    private readonly string bucketName = "stagewise-documents";

    public S3Service(IAmazonS3 s3)
    {
        _s3 = s3;
    }

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        using var stream = file.OpenReadStream();

        var uploadRequest = new TransferUtilityUploadRequest
        {
            InputStream = stream,
            Key = Guid.NewGuid().ToString(),
            BucketName = bucketName
        };

        var transferUtility = new TransferUtility(_s3);
        await transferUtility.UploadAsync(uploadRequest);

        return $"https://{bucketName}.s3.amazonaws.com/{uploadRequest.Key}";
    }
}
}

