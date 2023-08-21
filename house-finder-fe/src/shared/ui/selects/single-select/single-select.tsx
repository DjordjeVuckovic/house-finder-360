import {createTheme, FormControl, FormHelperText, MenuItem, Select, ThemeProvider} from "@mui/material";
import {SelectItemsProps} from "../select-props.ts";
export const SingleSelect = ({register,items,defaultValue,label,selectedItemValue}: SelectItemsProps) => {
    const theme = createTheme({
        components: {
            MuiSelect: {
                styleOverrides:{
                    select: {
                        '&:focus': {
                            backgroundColor: 'rgba(26, 28, 29,0.99)',
                            borderColor: 'hsl(225, 50%, 48%)',
                        },
                    },
                    icon: {
                        color: 'white'
                    }
                }
            }
        },
    });
    const bgList = 'rgba(26, 28, 29,0.99)'
    const selectionList = 'rgba(26, 28, 29,0.99)'
    const colorList = '#f5f8f2'
    return (
        <ThemeProvider theme={theme}>
            <FormControl>
                <FormHelperText sx={{
                    fontWeight: 600,
                    margin: '5px',
                    fontSize: 16,
                    color: '#ffffff'}}
                >
                    {label}
                </FormHelperText>
                <Select
                    MenuProps={{
                        sx: {
                            "&& .Mui-selected": {
                                backgroundColor: selectionList
                            },
                            "&& .MuiMenu-list": {
                                backgroundColor: bgList,
                                color: colorList
                            }
                        }
                    }}
                    displayEmpty
                    required
                    inputProps = {{'aria-label': 'Without label'}}
                    defaultValue = {selectedItemValue || defaultValue.value}
                    sx={{
                        color: '#ffffff',
                        backgroundColor: 'rgba(26, 28, 29,0.99)',
                        border: '2px solid rgba(255, 255, 255, 0.2)',
                        '& div:focus': {
                            outline: 'none',
                            border: '2px solid hsl(225, 50%, 48%)',
                        }
                    }}
                    componentsProps={{
                        listbox: {
                            sx: {backgroundColor: '#000'}
                        }
                    }}
                    {...register}
                >
                    {
                        items.map(item =>
                        <MenuItem value={item.value} key={item.value}>{item.text}</MenuItem>
                        )
                    }
                </Select>
            </FormControl>
        </ThemeProvider>
    );
};
