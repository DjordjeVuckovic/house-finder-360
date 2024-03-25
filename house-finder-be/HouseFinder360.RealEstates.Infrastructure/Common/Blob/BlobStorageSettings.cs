namespace HouseFinder360.RealEstates.Infrastructure.Common.Blob;

public class BlobStorageSettings
{
    public const string SectionName = "BlobStorage";
    public string BaseAddress { get; set; } = null!;
    public string Authorization { get; set; } = null!;
}
