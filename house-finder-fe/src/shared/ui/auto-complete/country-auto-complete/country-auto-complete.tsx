import { ChangeEvent, useMemo, useState } from 'react'
import { Country } from '../../../../core/search/model/city.ts'
import {
  Autocomplete,
  Box,
  createTheme,
  TextField,
  ThemeProvider,
} from '@mui/material'
import { CountryAutoCompleteProps } from '../auto-complete-props.ts'

export const CountryAutoComplete = ({
  onSearchChange,
  mode,
  width,
  countries,
  selectedCountry,
}: CountryAutoCompleteProps) => {
  const [inputValue, setInputValue] = useState('')
  const [_, setSelectedOption] = useState<Country | null>(null)
  const suggestions = useMemo(() => {
    return countries.filter((c: Country) =>
      c.name.toLowerCase().includes(inputValue.toLowerCase())
    )
  }, [countries, inputValue])
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
  const handleChange = (name: Country) => {
    setSelectedOption(name)
    onSearchChange(name)
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
        options={suggestions}
        autoComplete={true}
        autoHighlight
        value={selectedCountry || null}
        isOptionEqualToValue={(option, value) => option.name === value.name}
        getOptionLabel={(option) => option.name}
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
            {option.name}
          </Box>
        )}
        renderInput={(params) => (
          <TextField
            {...params}
            value={inputValue}
            onChange={handleInputChange}
            placeholder={'Select city'}
            style={{ color: color }}
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
