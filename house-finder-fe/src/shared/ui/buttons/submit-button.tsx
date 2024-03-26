import './buttons.scss'
import { SubmitButtonProps } from './button-props.ts'
import { CircularProgress } from '@mui/material'
export const SubmitButton = ({
  color,
  width,
  icon: Icon,
  children,
  onClick,
  type = 'button',
  isLoading,
  iconColor,
  disabled,
}: SubmitButtonProps) => {
  return (
    <button
      className={`submit-button`}
      style={{ color: color, width: width }}
      onClick={onClick}
      type={type}
      disabled={disabled}
    >
      {children}
      {isLoading ? (
        <CircularProgress size={20} style={{ color: iconColor }} />
      ) : (
        <div className={'submit-icon'}>
          {Icon && <Icon color={iconColor} size={20} />}
        </div>
      )}
    </button>
  )
}
