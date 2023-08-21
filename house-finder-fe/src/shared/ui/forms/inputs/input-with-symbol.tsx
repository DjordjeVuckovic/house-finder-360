import {InputWithSymbolProps} from "../form-props.ts";
import {FieldError} from "../../errors/FieldError.tsx";
import './inputs.scss'
import {useState} from "react";

export const InputWithSymbol = (
    {label,placeholder,type = 'text',register,error,width,symbol} : InputWithSymbolProps) => {
    const [isFocused, setIsFocused] = useState(false);

    const handleFocus = () => {
        setIsFocused(true);
    };

    const handleBlur = () => {
        setIsFocused(false);
    };
    return (
        <div style={{width: width}}>
            <label style={{
                fontWeight: 600,
                margin: '5px',
                fontSize: 16,
                color: '#ffffff'}}

            >{label}</label>
            <div className={`inputs-group ${isFocused ? 'focused' : ''}`}>
                <input
                    className={'input-transparent'}
                    {...register}
                    placeholder={placeholder}
                    type = {type}
                    onFocus={handleFocus}
                    onBlur={handleBlur}
                />
                <span className={`symbol ${isFocused ? 'focused' : ''}`}>{symbol}</span>
            </div>
            {error && (
                <FieldError error={error}/>
            )}
        </div>
    );
};
