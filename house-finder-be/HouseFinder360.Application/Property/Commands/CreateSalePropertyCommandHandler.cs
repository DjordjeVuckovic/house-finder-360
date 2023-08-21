using FluentResults;
using HouseFinder360.Application.Common.BlobStorage;
using HouseFinder360.Application.Common.Interfaces.Persistence.Generic;
using HouseFinder360.Domain.Property.Entities;
using HouseFinder360.Domain.Property.ValueObjects;
using MediatR;

namespace HouseFinder360.Application.Property.Commands;

public class CreateSalePropertyCommandHandler : IRequestHandler<CreateSalePropertyCommand,Result>
{
    private readonly IDbContext _dbContext;
    private readonly BlobHandler _blobHandler;

    public CreateSalePropertyCommandHandler(
        IDbContext dbContext, 
        BlobHandler blobHandler)
    {
        _dbContext = dbContext;
        _blobHandler = blobHandler;
    }

    public async Task<Result> Handle(CreateSalePropertyCommand request, CancellationToken cancellationToken)
    {
        var address = new Address(
            new Location
            {
                Name = request.Address.Street,
                Latitude = request.Address.StreetLatitude,
                Longitude = request.Address.StreetLongitude
            }, 
            new Location
            {
                Name = request.Address.City,
                Latitude = request.Address.CityLatitude,
                Longitude = request.Address.CityLongitude
            }, 
            request.Address.Country);
        var filesFromBlob = await _blobHandler.HandleMultipleUploadDefaultContainer(request.Photos!);
        if (filesFromBlob.IsFailed) return Result.Fail(filesFromBlob.Errors.First());
        var propertyPhotos = filesFromBlob.Value.Select(x =>
        new PropertyPhoto {
            Name = x.Name,
            Uri = x.Uri,
            Container = CreateContainer.DefaultName
        });
        var salePropertyResult = Domain.Property.Property.CreateSaleProperty(
            request.Title,
            request.Description,
            request.Area,
            request.RoomsNumber, 
            address, 
            request.Condition,
            request.Floor, 
            request.TotalFloors, 
            request.Price,
            request.Type, 
            request.RegisterStatus, 
            request.Heating, 
            request.ElevatorsNumber,
            request.BalconiesNumber,
            request.BathroomsNumber, 
            request.ToiletsNumber, 
            request.YearOfBuild,
            propertyPhotos.ToList());
        
        if (salePropertyResult.IsFailed) return Result.Fail(salePropertyResult.Errors);
        
        await _dbContext.Properties.AddAsync(salePropertyResult.Value, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}