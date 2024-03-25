import { Button } from '@mui/material'
import { CustomButtonProps } from '../../common'

export const CustomButton = ({
  title,
  bgColor,
  color,
  fullWidth,
  icon,
  handleClick,
  isCapital,
}: CustomButtonProps) => {
  return (
    <Button
      sx={{
        flex: fullWidth ? 1 : 'unset',
        padding: '.5rem 1rem',
        width: fullWidth ? '100%' : 'fit-content',
        background: bgColor,
        color,
        fontSize: 16,
        fontWeight: 550,
        borderRadius: '16px',
        gap: '10px',
        textTransform: isCapital ? 'uppercase' : 'inherit',
        '&:hover': {
          cursor: 'pointer',
          transform: 'scale(1.02)',
          opacity: 0.9,
          background: 'linear-gradient(30.05deg, #40a9ff 3.76%, #2978c6 100%)',
        },
      }}
      onClick={handleClick}
    >
      {icon}
      {title}
    </Button>
  )
}
