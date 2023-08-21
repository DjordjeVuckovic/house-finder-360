export interface ToastProps{
    message: string;
    severity: "error" | "warning" | "info" | "success";
    isOpen: boolean;
    onClose: () => void;
}
export interface ToastContextProps {
    showToast: (message: string, severity: "error" | "warning" | "info" | "success") => void;
}
