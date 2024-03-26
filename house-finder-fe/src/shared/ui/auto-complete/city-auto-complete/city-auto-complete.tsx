import { ChangeEvent, useMemo, useState } from 'react'
import { City } from '../../../../core/search/model/city.ts'
import {
  Autocomplete,
  Box,
  createTheme,
  TextField,
  ThemeProvider,
} from '@mui/material'
import { CityAutoCompleteProps } from '../auto-complete-props.ts'

export const CityAutoComplete = ({
  onSearchChange,
  mode,
  width,
  cities,
  selectedCity,
}: CityAutoCompleteProps) => {
  const [inputValue, setInputValue] = useState('')
  const suggestions = useMemo(() => {
    return cities.filter(
      (city: City) =>
        city.city.toLowerCase().includes(inputValue.toLowerCase()) ||
        city.country.toLowerCase().includes(inputValue.toLowerCase())
    )
  }, [cities, inputValue])
  const bg =
    mode === 'dark' ? 'rgba(26, 28, 29,0.99) !important' : '#ffffff !important'
  const border =
    mode === 'dark'
      ? '2px solid rgba(255, 255, 255, 0.2) !important'
      : '1px solid hsl(225, 50%, 48%) !important'
  const color = mode === 'dark' ? '#f5f8f2 !important' : 'black'
  const colorLetters = mode === 'dark' ? 'white' : 'black !important'
  const bgListbox =
    mode === 'dark' ? 'rgba(26, 28, 29,0.99)' : 'white !important'
  const handleInputChange = (event: ChangeEvent<HTMLInputElement>) => {
    const input = event.target.value
    setInputValue(input)
  }
  const handleChange = (city: City) => {
    onSearchChange(city)
  }
  const theme = createTheme({
    components: {
      // Name of the component
      MuiAutocomplete: {
        styleOverrides: {
          inputRoot: {
            color: color,
            '& .MuiOutlinedInput-notchedOutline': {
              borderColor: border,
            },
            '&:hover .MuiOutlinedInput-notchedOutline': {
              borderColor: border,
            },
            '&.Mui-focused .MuiOutlinedInput-notchedOutline': {
              borderColor: border,
              color: colorLetters,
            },
            '&& .MuiSvgIcon-root': {
              borderColor: border,
              color: 'red',
            },
          },
          listbox: {
            backgroundColor: bgListbox,
            color: colorLetters,
          },
        },
      },
    },
  })
  return (
    <ThemeProvider theme={theme}>
      <Autocomplete
        id='city-select'
        sx={{
          background: bg,
          borderRadius: '8px',
          border: border,
          width: width,
        }}
        value={selectedCity || null}
        options={suggestions}
        autoComplete={true}
        autoHighlight
        isOptionEqualToValue={(option, value) =>
          option.city === value.city && option.country === value.country
        }
        getOptionLabel={(option) => option.city}
        renderOption={(props, option) => (
          <Box
            component='li'
            sx={{ '& > img': { mr: 2, flexShrink: 0 } }}
            {...props}
          >
            <img
              loading='lazy'
              width='20'
              src={`https://flagcdn.com/w20/${option.iso2.toLowerCase()}.png`}
              srcSet={`https://flagcdn.com/w40/${option.iso2.toLowerCase()}.png 2x`}
              alt='city'
            />
            {option.city} ({option.country})
          </Box>
        )}
        renderInput={(params) => (
          <TextField
            {...params}
            value={inputValue}
            onChange={handleInputChange}
            placeholder={'Select city'}
            style={{
              color: color,
            }}
            inputProps={{
              ...params.inputProps,
              autoComplete: Math.random().toString(),
            }}
          />
        )}
        onChange={(_, value) => handleChange(value)}
      />
    </ThemeProvider>
  )
}
