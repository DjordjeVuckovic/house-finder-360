import {City, Country} from "../../../core/search/model/city.ts";

export interface CountryAutoCompleteProps {
    onSearchChange: any;
    mode: string,
    width: string | number,
    countries: Country[],
    selectedCountry?: Country
}
export interface CityAutoCompleteProps {
    onSearchChange: any;
    mode: string,
    width: string | number,
    cities: City[],
    selectedCity?: City
}