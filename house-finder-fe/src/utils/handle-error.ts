import {AxiosError} from "axios";
export interface HandleError{
    error: string;
    errors: string[];
}
export function handleError(err: AxiosError): string | null {
    const errorData = err.response.data as HandleError
    if( errorData.errors.length === 0) {
        return errorData.error
    }
    return errorData.errors.join('\n')
}