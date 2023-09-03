import {httpClient} from "../../http-client/http-client.ts";
import {PropertyResponse} from "../model/property-response.ts";

const BASE_URL = import.meta.env.VITE_BE_BASE_URL
export const createSaleProperty = async (data: FormData) => {
    const response = await httpClient.post(`${BASE_URL}/api/v1/properties`, data);
    return response.data;
};
export const getUserProperties = async (userId : string): Promise<PropertyResponse[]> => {
    const response = await httpClient.get(`${BASE_URL}/api/v1/properties/${userId}`);
    return response.data;
};
export const fetchProperties = async (currentPage: number,pageSize: number) => {
    const response =
        await httpClient.get(`${BASE_URL}/api/v1/properties?currentPage=${currentPage}&pageSize=${pageSize}`);
    return response.data;
}
export const fetchPropertiesPaginate = async ({pageParam = 1}) => {
    return fetchProperties(pageParam,5)
}