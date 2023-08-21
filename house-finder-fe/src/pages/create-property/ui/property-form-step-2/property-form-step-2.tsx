import {FormControl, FormHelperText, Typography} from "@mui/material";
import {useMemo, useState} from "react";
import {City, Country} from "../../../../core/search/model/city.ts";
import {citiesAndCountries, countries} from "../../../../core/search/data-access/cities.ts";
import {CityAutoComplete, CountryAutoComplete} from "../../../../shared/ui/auto-complete";
import {InputCore} from "../../../../shared/ui/forms";
import {MdNavigateBefore, MdOutlineNavigateNext} from "react-icons/md";
import {ButtonWithIcon} from "../../../../shared/ui/buttons";

export const PropertyFormStep2 = ({
                                      type,
                                      register,
                                      handleSubmit,
                                      errors,
                                      setValue,
                                      onFinishHandler,
                                      onBack,
                                      getValues
}) => {
    const [selectedCity, setSelectedCity] =
        useState<City | null>(null);
    const [selectedCountry, setSelectedCountry] =
        useState<Country | null>(null);
    //const [cities, _] = useState<City[]>(citiesAndCountries);
    //const [countriesList, __] = useState<Country[]>(countries);
    const cities = citiesAndCountries
    const countriesList = countries
    const handleCityChange = (city: City): void => {
        setSelectedCity(city);
        setValue('address.city', city);
    };

    const handleCountryChange = (c: Country): void => {
        setSelectedCountry(c)
        setValue('address.country', c);
    }
    const filteredCities = useMemo(() => {
        if (selectedCountry) {
            return cities.filter(x => x.country === selectedCountry.name)
        }
        return cities;
    }, [selectedCountry, cities]);

    const filteredCountries = useMemo(() => {
        if (selectedCity) {
            return countriesList.filter(x => x.name === selectedCity.country)
        }
        return countriesList;
    }, [selectedCity, countriesList]);
    return (
        <form style={{
            display: 'flex',
            flexDirection: 'column',
            gap: '1.2rem'
        }}
              onSubmit={handleSubmit(onFinishHandler)}
        >
            <Typography fontSize={25} fontWeight={700} color="#ffffff">
                {type} a Property <span className={'step-count'}>(location)</span>
            </Typography>
            <div className={'grid-2-c'}>
                <FormControl>
                    <FormHelperText sx={{
                        fontWeight: 600,
                        margin: '5px',
                        fontSize: 16,
                        color: '#ffffff'}}

                    >Select country</FormHelperText>
                    <div className={'city-auto-complete'}>
                        <CountryAutoComplete onSearchChange={handleCountryChange}
                                             mode={'dark'}
                                             width={'100%'}
                                             countries={filteredCountries}
                                             selectedCountry={getValues('address.country')}/>
                    </div>
                </FormControl>
                <FormControl>
                    <FormHelperText sx={{
                        fontWeight: 600,
                        margin: '5px',
                        fontSize: 16,
                        color: '#ffffff'}}

                    >Select city</FormHelperText>
                    <div className={'city-auto-complete'}>
                        <CityAutoComplete onSearchChange={handleCityChange}
                                          mode={'dark'}
                                          width={'100%'}
                                          cities={filteredCities}
                                          selectedCity={getValues('address.city')}
                        />
                    </div>
                </FormControl>
            </div>
            <InputCore
                key={'address.street'}
                label={'Enter property location'}
                register={register('address.street',
                    {required: {
                            value: true,
                            message: 'Property location is required'
                        }})}
                error={errors.address?.street?.message}
                placeholder={'Enter a location'}/>
            <div className={'grid-2-c'}>
                <InputCore
                    key={'address.longitude'}
                    label={'Enter property longitude'}
                    type={'number'}
                    register={register('address.longitude',
                        {
                            valueAsNumber: true,
                            required: {
                                value: true,
                                message: 'Property longitude is required'
                            }})}
                    error={errors.address?.longitude?.message}
                    placeholder={'Enter a longitude'}
                />
                <InputCore
                    key={'address.latitude'}
                    label={'Enter property latitude'}
                    type={'number'}
                    register={register('address.latitude',
                        {
                            valueAsNumber: true,
                            required: {
                                value: true,
                                message: 'Property latitude is required'
                            }})}
                    error={errors.address?.latitude?.message}
                    placeholder={'Enter a latitude'}
                />
            </div>
            <div className={'btn-group'}>
                <ButtonWithIcon type={'button'}
                                bgColor={'linear-gradient(97.05deg, #4066ff 3.76%, #2949c6 100%)'}
                                color={'#f5f8f2'}
                                icon={MdNavigateBefore}
                                width={'20%'}
                                onClick={onBack}>
                    Back
                </ButtonWithIcon>
                <ButtonWithIcon type={'submit'}
                                bgColor={'linear-gradient(97.05deg, #4066ff 3.76%, #2949c6 100%)'}
                                color={'#f5f8f2'}
                                icon={MdOutlineNavigateNext}
                                width={'20%'}
                                iconFirst={false}>
                    Next
                </ButtonWithIcon>
            </div>
        </form>
    );
};
