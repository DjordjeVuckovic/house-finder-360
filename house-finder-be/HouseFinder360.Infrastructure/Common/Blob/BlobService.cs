using System.Net.Http.Headers;
using System.Net.Http.Json;
using HouseFinder360.Application.Common.BlobStorage;
using Microsoft.AspNetCore.Http;

namespace HouseFinder360.Infrastructure.Common.Blob;

public class BlobService : IBlobService
{
    private readonly HttpClient _client;

    public BlobService(HttpClient client)
    {
        _client = client;
    }
    public async Task<HttpResponseMessage> CreateContainer(string containerName)
    {
        var container = new CreateContainer{Name = containerName};
        return await _client.PostAsJsonAsync($"api/v1/containers", container);
    }

    public async Task<HttpResponseMessage> UploadFile(string containerName, IFormFile file)
    {
        var formData = new MultipartFormDataContent(Guid.NewGuid().ToString());
        formData.Add(new StreamContent(file.OpenReadStream()), "file", file.FileName);
        return await _client.PostAsync($"api/v1/files/{containerName}", formData);
    }
    public async Task<HttpResponseMessage> UploadFileDefaultContainer(IFormFile file)
    {
        var formData = new MultipartFormDataContent(Guid.NewGuid().ToString());
        formData.Add(new StreamContent(file.OpenReadStream()), "file", file.FileName);
        return await _client.PostAsync($"api/v1/files/{Application.Common.BlobStorage.CreateContainer.DefaultName}", formData);
    }
    public async Task<HttpResponseMessage> UploadMultipleFilesDefaultContainer(IFormFileCollection files)
    {
        
        using var content = new MultipartFormDataContent();

        foreach (var file in files)
        {
            var fileContent = new StreamContent(file.OpenReadStream())
            {
                Headers =
                {
                    ContentLength = file.Length,
                    ContentType = new MediaTypeHeaderValue(file.ContentType)
                }
            };

            content.Add(fileContent, "files", file.FileName);
        }
        return await _client.PostAsync($"api/v1/files/multiple/{Application.Common.BlobStorage.CreateContainer.DefaultName}", content);
    }
}