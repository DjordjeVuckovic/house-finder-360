import {HiLocationMarker} from "react-icons/hi";
import {ChangeEvent, useMemo, useState} from "react";
import {citiesAndCountries} from './data-access/cities.ts'
import {City} from "./model/city.ts";
import {Autocomplete, Box, TextField} from "@mui/material";
import "./search.scss"

export const Searchbar = ({onSearch,onSearchChange}) => {
    const [inputValue, setInputValue] = useState('');
    const [cities] = useState<City[]>(citiesAndCountries);
    const [selectedOption, setSelectedOption] = useState<City| null>(null);
    const suggestions = useMemo(() => {
         return cities.filter((city: City) =>
             city.city.toLowerCase().includes(inputValue.toLowerCase()) ||
             city.country.toLowerCase().includes(inputValue.toLowerCase())
         );
    },[cities,inputValue])
    const handleInputChange = (event: ChangeEvent<HTMLInputElement>) => {
        const input = event.target.value;
        setInputValue(input);
    };
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
            <Autocomplete id="city-select"
                          sx={{ width: 300,background:'#F5F8F2FF',borderRadius:'2px'}}
                          options={suggestions}
                          color={'secondary'}
                          autoComplete={true}
                          autoHighlight
                          isOptionEqualToValue={(option, value) =>
                              option.city === value.city && option.country === value.country}
                          getOptionLabel={(option) => option.city}
                          renderOption={(props, option) => (
                <Box component="li" sx={{ '& > img': { mr: 2, flexShrink: 0 } }} {...props}>
                    <img
                        loading="lazy"
                        width="20"
                        src={`https://flagcdn.com/w20/${option.iso2.toLowerCase()}.png`}
                        srcSet={`https://flagcdn.com/w40/${option.iso2.toLowerCase()}.png 2x`}
                        alt=""
                    />
                    {option.city} ({option.country})
                </Box>
            )}
                      renderInput={(params) => (
                          <TextField
                              {...params}
                              value={inputValue}
                              onChange={handleInputChange}
                              inputProps={{
                                  ...params.inputProps,
                                  autoComplete: 'new-password',
                              }}
                          />
                      )}
                          onChange={(_, value) => handleChange(value)}
            />
            <button className={'btn-primary'} onClick={handleSearch}>Search</button>
        </div>
    );
};
