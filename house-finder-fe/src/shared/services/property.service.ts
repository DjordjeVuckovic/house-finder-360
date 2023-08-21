import axios from "axios";
const BASE_URL = import.meta.env.VITE_BE_BASE_URL
export const createSaleProperty = async (data: FormData) => {
    const response = await axios.post(`${BASE_URL}/api/v1/sale-properties`, data);
    return response.data;
};