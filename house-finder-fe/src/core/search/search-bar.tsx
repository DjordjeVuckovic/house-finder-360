import {HiLocationMarker} from "react-icons/hi";
import {City} from "./model/city.ts";
import "./search.scss"
import {AiOutlineSearch} from "react-icons/ai";
import {CityAutoComplete} from "../../shared/ui/auto-complete";
import {citiesAndCountries} from "./data-access/cities.ts";
import {usePropertyStore} from "../../shared/state/property.state.ts";

export const SearchBar = ({onSearch,mode}) => {
    const {setSelectedCity} = usePropertyStore()
    const cities = citiesAndCountries
    const handleSearch = () => {
        onSearch();
    };
    const handleChange = (city: City) => {
        setSelectedCity(city);
    }
    return (
        <div className={'search-bar'}>
            <div className={'icon-search'}>
                <HiLocationMarker color={'#4066ff'} size={30}/>
            </div>
            <CityAutoComplete onSearchChange={handleChange}
                              mode={mode}
                              width={300}
                              cities={cities}/>
            <button className={'btn-primary flex-center-align g-3'}
                    onClick={handleSearch}><AiOutlineSearch/> Search</button>
        </div>
    );
};
