import {SignInRequest} from "./auth.model.ts";
import {httpClient} from "../http-client/http-client.ts";
const BASE_URL = import.meta.env.VITE_BE_BASE_URL
export const logIn = async (data: SignInRequest) => {
    const response = await httpClient.post(`${BASE_URL}/api/v1/auth`, data);
    return response.data;
};