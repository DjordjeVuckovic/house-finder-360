import {HiLocationMarker} from "react-icons/hi";
import {useState} from "react";
import {City} from "./model/city.ts";
import "./search.scss"
import {AiOutlineSearch} from "react-icons/ai";
import {CityAutoComplete} from "../../shared/ui/auto-complete";
import {citiesAndCountries} from "./data-access/cities.ts";

export const SearchBar = ({onSearch,onSearchChange,mode}) => {
    const [selectedOption, setSelectedOption] = useState<City| null>(null);
    const cities = citiesAndCountries
    const handleSearch = () => {
        if(selectedOption){
            onSearch();
        }
    };
    const handleChange = (city: City) => {
        setSelectedOption(city);
        onSearchChange(city);
    }
    return (
        <div className={'search-bar'}>
            <div className={'icon'}>
                <HiLocationMarker color={'#4066ff'} size={30}/>
            </div>
            <CityAutoComplete onSearchChange={handleChange}
                              mode={mode}
                              width={300}
                              cities={cities}/>
            <button className={'btn-primary flex-center-align g-3'} onClick={handleSearch}><AiOutlineSearch/> Search</button>
        </div>
    );
};
