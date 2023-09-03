
export interface PropertyCardProps {
    title: string;
    price: number;
    address: string;
    bathrooms: number;
    bedrooms: string;
    area: number;
    purpose: string;
    image: string;
    description?:  string;
    theme?: "dark" | "light";
}