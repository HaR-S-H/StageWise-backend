public class S3UploadMessage
{
    public byte[] FileBytes { get; set; } = default!;
    public string FileName { get; set; } = default!;
    public string ContentType { get; set; } = default!;
    public string Key { get; set; } = default!;
}