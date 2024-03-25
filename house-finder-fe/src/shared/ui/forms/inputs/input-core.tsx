import { InputProps } from '../form-props.ts'
import { FieldError } from '../../errors/FieldError.tsx'

export const InputCore = ({
  label,
  placeholder,
  type = 'text',
  register,
  error,
  width,
}: InputProps) => {
  return (
    <div style={{ width: width }}>
      <label
        style={{
          fontWeight: 600,
          margin: '5px',
          fontSize: 16,
          color: '#ffffff',
        }}
      >
        {label}
      </label>
      <input
        className={'input-base'}
        {...register}
        placeholder={placeholder}
        type={type}
        step='any'
      />
      {error && <FieldError error={error} />}
    </div>
  )
}
