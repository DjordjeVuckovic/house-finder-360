import Snackbar from '@mui/material/Snackbar';
import Alert from '@mui/material/Alert';
import {ToastProps} from "./toast-props.ts";
import React from "react";

export const Toaster = ({message,severity,isOpen,onClose} : ToastProps) => {
    const handleClose = (_?: React.SyntheticEvent, reason?: string) => {
        if (reason === 'clickaway') {
            return;
        }
        onClose();
    };
    return (
        <div>
            <Snackbar
                open={isOpen}
                autoHideDuration={4000}
                onClose={handleClose}
                anchorOrigin={{ vertical: 'bottom', horizontal: 'right' }}
            >
                <Alert onClose={handleClose} severity={severity} sx={{ width: '100%' }}>
                    {message}
                </Alert>
            </Snackbar>
        </div>
    );
};