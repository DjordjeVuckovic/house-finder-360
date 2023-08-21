namespace HouseFinder360.Application.Common.BlobStorage;

public class UploadFileResponse
{
    public string Name { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public string Uri { get; set; } = null!;
}