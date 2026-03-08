public interface IS3Service
{
    Task UploadBytesAsync(byte[] fileBytes, string key, string contentType);
}