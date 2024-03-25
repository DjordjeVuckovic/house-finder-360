import { Stack, Typography } from '@mui/material'
import { MdOutlineErrorOutline } from 'react-icons/md'

export const FieldError = ({ error }) => {
  return (
    <Stack direction='row' gap={1} sx={{ padding: '1rem 1rem 1rem 0' }}>
      <MdOutlineErrorOutline color={'#ff4040'} size={20} />
      <Typography sx={{ color: '#ff4040' }}>{error}</Typography>
    </Stack>
  )
}
