import ReactApexChart from 'react-apexcharts'
import { Box, Stack, Typography } from '@mui/material'
import { ArrowCircleUpRounded } from '@mui/icons-material'
import { TotalRevenueOptions, TotalRevenueSeries } from './mock/chart.config.ts'

import './charts.scss'

export const TotalRevenue = () => {
  return (
    <Box
      p={4}
      flex={1}
      bgcolor='rgb(26, 28, 29)'
      id='chart'
      display='flex'
      flexDirection='column'
      borderRadius='15px'
    >
      <Typography fontSize={18} fontWeight={600} color='#f5f8f2'>
        Total Revenue
      </Typography>
      <Stack my='20px' direction='row' gap={4} flexWrap='wrap'>
        <Typography fontSize={28} fontWeight={720} color='#f5f8f2'>
          $236,535
        </Typography>
        <Stack direction='row' alignItems='center' gap={1}>
          <ArrowCircleUpRounded
            sx={{
              fontSize: 25,
              color: '#475be8',
            }}
          />
          <Stack>
            <Typography fontSize={15} fontWeight={500} color='#f5f8f2'>
              0.5%
            </Typography>
            <Typography fontSize={12} fontWeight={600} color='#f5f8f2'>
              Than last month
            </Typography>
          </Stack>
        </Stack>
      </Stack>
      <ReactApexChart
        series={TotalRevenueSeries}
        type='bar'
        height={310}
        options={TotalRevenueOptions}
      />
    </Box>
  )
}
