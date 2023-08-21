import {ElementType, ReactNode} from "react";

export interface ButtonWithIconProps {
    color: string,
    bgColor: string,
    icon: ElementType,
    children: ReactNode,
    width: string;
    onClick?: () => void;
    type?: "button" | "reset" | "submit";
    className?: string
    iconFirst?: boolean
}
export interface SubmitButtonProps {
    color: string,
    iconColor: string,
    icon: ElementType,
    children: ReactNode,
    width: string;
    onClick?: () => void;
    type?: "button" | "reset" | "submit";
    isLoading: boolean
    disabled: boolean
}