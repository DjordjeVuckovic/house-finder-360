import {FieldError, FieldErrorsImpl, Merge, UseFormRegisterReturn} from "react-hook-form";

export interface InputProps {
    register: UseFormRegisterReturn;
    label: string;
    placeholder?: string;
    type?: string;
    width?: string;
    error: string | FieldError | Merge<FieldError, FieldErrorsImpl<any>>;
}
export interface InputWithSymbolProps {
    register: UseFormRegisterReturn;
    label: string;
    placeholder?: string;
    type?: string;
    width?: string;
    error: string | FieldError | Merge<FieldError, FieldErrorsImpl<any>>;
    symbol: any;
}
export interface TextAreaProps {
    height?: string;
    register: UseFormRegisterReturn;
    label: string;
    placeholder?: string;
    error: string | FieldError | Merge<FieldError, FieldErrorsImpl<any>>;
}