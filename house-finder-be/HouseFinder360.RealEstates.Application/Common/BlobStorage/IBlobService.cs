using Microsoft.AspNetCore.Http;

namespace HouseFinder360.RealEstates.Application.Common.BlobStorage;

public interface IBlobService
{
    Task<HttpResponseMessage> CreateContainer(string containerName);
    Task<HttpResponseMessage> UploadFile(string containerName, IFormFile file);
    Task<HttpResponseMessage> UploadFileDefaultContainer(IFormFile file);
    Task<HttpResponseMessage> UploadMultipleFilesDefaultContainer(IFormFileCollection files);
}