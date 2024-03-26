import { createContext, useState } from 'react'
import { ToastContextProps, ToastProps } from './toast-props.ts'
import { Toaster } from './toaster.tsx'

export const ToastContext = createContext<ToastContextProps | undefined>(
  undefined
)

export const ToastProvider = ({ children }) => {
  const [toastProps, setToastProps] = useState<ToastProps | null>(null)
  const closeToast = () => {
    setToastProps(null)
  }
  const showToast = (
    message: string,
    severity: 'error' | 'warning' | 'info' | 'success'
  ) => {
    setToastProps({ message, severity, isOpen: true, onClose: closeToast })
  }
  return (
    <ToastContext.Provider value={{ showToast }}>
      {children}
      {toastProps && <Toaster {...toastProps} />}
    </ToastContext.Provider>
  )
}
