import {TextAreaProps} from "../form-props.ts";
import {FormControl, FormHelperText} from "@mui/material";
import {FieldError} from "../../errors/FieldError.tsx";

export const TextAreaBase = ({label,placeholder,register,error,height} : TextAreaProps) => {
    return (
            <FormControl>
                <FormHelperText sx={{
                    fontWeight: 600,
                    margin: '5px',
                    fontSize: 16,
                    color: '#ffffff'}}

                >{label}</FormHelperText>
                <textarea
                    className={'input-base'}
                    style={{height: height}}
                    {...register}
                    placeholder={placeholder}
                    color="primary"
                />
                {error && (
                    <FieldError error={error}/>
                )}
            </FormControl>
    );
};
