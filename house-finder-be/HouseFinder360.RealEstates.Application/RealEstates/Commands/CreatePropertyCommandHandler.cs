using FluentResults;
using HouseFinder360.RealEstates.Domain.RealEstates;
using HouseFinder360.RealEstates.Domain.RealEstates.Entities;
using HouseFinder360.RealEstates.Domain.RealEstates.ValueObjects;
using HouseFinder360.RealEstates.Application.Common.BlobStorage;
using HouseFinder360.RealEstates.Application.Common.Interfaces.Persistence.Generic;
using MediatR;

namespace HouseFinder360.RealEstates.Application.RealEstates.Commands;

public class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, Result>
{
    private readonly IDbContext _dbContext;
    private readonly BlobHandler _blobHandler;

    public CreatePropertyCommandHandler(
        IDbContext dbContext,
        BlobHandler blobHandler)
    {
        _dbContext = dbContext;
        _blobHandler = blobHandler;
    }

    public async Task<Result> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
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
        new PropertyPhoto
        {
            Name = x.Name,
            Uri = x.Uri,
            Container = CreateContainer.DefaultName
        });
        var salePropertyResult = RealEstate.CreateSaleProperty(
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
            propertyPhotos.ToList(),
            request.UserId,
            request.ListingType);

        if (salePropertyResult.IsFailed) return Result.Fail(salePropertyResult.Errors);

        await _dbContext.Properties.AddAsync(salePropertyResult.Value, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}
