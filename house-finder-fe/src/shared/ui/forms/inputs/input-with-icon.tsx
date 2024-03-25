import { InputProps } from '../form-props.ts'
import { FormControl, FormHelperText } from '@mui/material'
import { FieldError } from '../../errors/FieldError.tsx'

export const InputWithIcon = ({
  label,
  placeholder,
  type = 'text',
  register,
  error,
  width,
}: InputProps) => {
  return (
    <FormControl sx={{ width: width }}>
      <FormHelperText
        sx={{
          fontWeight: 600,
          margin: '5px',
          fontSize: 16,
          color: '#ffffff',
        }}
      >
        {label}
      </FormHelperText>
      <input
        className={'input-base'}
        {...register}
        placeholder={placeholder}
        type={type}
      />
      {error && <FieldError error={error} />}
    </FormControl>
  )
}
