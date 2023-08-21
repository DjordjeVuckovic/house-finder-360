import {City, Country} from "../../../core/search/model/city.ts";

export interface SaleProperty {
    title: string;
    description: string;
    address: Address;
    propertyType: string;
    area: number;
    roomsNumber: string;
    registerStatus: string;
    condition: string;
    heating: string;
    elevatorsNumber: number;
    floor: string;
    totalFloors: string;
    price: number;
    photos: FormData[];
    yearOfBuild: Date;
    toiletsNumber: number;
    balconiesNumber: number;
    bathroomsNumber: number;
}
export interface Address{
    country: Country;
    city: City;
    street: string;
    longitude: number;
    latitude: number;
}
export interface SalePropertyRequest {
    title: string;
    description: string;
    roomsNumber: string;
    address: AddressRequest;
    condition: string;
    area: number;
    floor: string;
    totalFloors: string;
    price: number;
    type: string;
    registerStatus: string;
    heating: string;
    elevatorsNumber: number;
    numberOfToilets: number;
    bathroomsNumber: number;
    numberOfBalconies: number;
    files?: FormData;
}

export interface AddressRequest {
    street: string;
    city: string;
    cityLongitude: number;
    cityLatitude: number;
    country: string;
    streetLongitude: number;
    streetLatitude: number;
}
