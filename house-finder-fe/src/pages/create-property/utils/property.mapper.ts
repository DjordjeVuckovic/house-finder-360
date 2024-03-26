import {
  Address,
  AddressRequest,
  SaleProperty,
  SalePropertyRequest,
} from '../model/property.ts'

export function mapSalePropertyToRequest(
  saleProperty: SaleProperty
): SalePropertyRequest {
  return {
    title: saleProperty.title,
    description: saleProperty.description,
    roomsNumber: saleProperty.roomsNumber,
    address: mapAddressToAddressRequest(saleProperty.address),
    condition: saleProperty.condition,
    area: saleProperty.area,
    floor: saleProperty.floor,
    totalFloors: saleProperty.totalFloors,
    price: saleProperty.price,
    type: saleProperty.propertyType,
    registerStatus: saleProperty.registerStatus,
    heating: saleProperty.heating,
    elevatorsNumber: saleProperty.elevatorsNumber,
    numberOfToilets: saleProperty.toiletsNumber,
    bathroomsNumber: saleProperty.bathroomsNumber,
    numberOfBalconies: saleProperty.balconiesNumber,
    listingType: saleProperty.listingType,
  }
}

export function mapAddressToAddressRequest(address: Address): AddressRequest {
  return {
    street: address.street,
    city: address.city.city,
    cityLongitude: address.city.lng,
    cityLatitude: address.city.lat,
    country: address.country.name,
    streetLongitude: address.longitude,
    streetLatitude: address.latitude,
  }
}
