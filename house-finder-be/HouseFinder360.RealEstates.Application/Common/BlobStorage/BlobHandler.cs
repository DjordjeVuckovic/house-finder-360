using System.Text.Json;
using FluentResults;
using Microsoft.AspNetCore.Http;

namespace HouseFinder360.RealEstates.Application.Common.BlobStorage;

public class BlobHandler
{
    private readonly IBlobService _blobService;

    public BlobHandler(IBlobService blobService)
    {
        _blobService = blobService;
    }

    public async Task<Result<List<UploadFileResponse>>> HandleMultipleUploadDefaultContainer(
        IFormFileCollection files)
    {
        try
        {
            var response = await _blobService.UploadMultipleFilesDefaultContainer(files);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            return JsonSerializer.Deserialize<List<UploadFileResponse>>(responseContent,options) 
                   ?? new List<UploadFileResponse>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Result.Fail("Cannot upload files!");
        }
    }
}