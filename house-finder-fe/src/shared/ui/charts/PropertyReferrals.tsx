import { Box, Stack, Typography } from '@mui/material'
import { propertyReferralsInfo } from '../../constants/constants.ts'

import './charts.scss'
interface ProgressBarProps {
  title: string
  percentage: number
  color: string
}
const ProgressBar = ({ title, percentage, color }: ProgressBarProps) => (
  <Box width='100%'>
    <Stack direction='row' alignItems='center' justifyContent='space-between'>
      <Typography fontSize={16} fontWeight={520} color='#f5f8f2'>
        {title}
      </Typography>
      <Typography fontSize={16} fontWeight={520} color='#11142d'>
        {percentage}%
      </Typography>
    </Stack>
    <Box
      mt={2}
      position='relative'
      width='100%'
      height='10px'
      borderRadius={2}
      bgcolor='#e4e8ef'
    >
      <Box
        width={`${percentage}%`}
        bgcolor={color}
        position='absolute'
        height='100%'
        borderRadius={1}
      />
    </Box>
  </Box>
)

export const PropertyReferrals = () => {
  return (
    <Box
      p={4}
      bgcolor='rgb(26, 28, 29)'
      id='chart'
      minWidth={490}
      display='flex'
      flexDirection='column'
      borderRadius='15px'
    >
      <Typography fontSize={18} fontWeight={600} color='#f5f8f2'>
        Property Referrals
      </Typography>
      <Stack my='20px' direction='column' gap={4}>
        {propertyReferralsInfo.map((bar) => (
          <ProgressBar {...bar} key={bar.title} />
        ))}
      </Stack>
    </Box>
  )
}
