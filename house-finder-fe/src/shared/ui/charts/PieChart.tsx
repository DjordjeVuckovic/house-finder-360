import ReactApexChart from 'react-apexcharts'
import { PieChartProps } from './data/pie'
import { Box, Stack, Typography } from '@mui/material'
import './charts.scss'
export const PieChart = ({ title, value, series, colors }: PieChartProps) => {
  return (
    <Box
      id='chart'
      flex={1}
      display='flex'
      bgcolor='rgba(26, 28, 29,0.99)'
      flexDirection='row'
      justifyContent='space-between'
      alignItems='center'
      pl={3.5}
      pr={1}
      py={2}
      gap={2}
      borderRadius='15px'
      minHeight='120px'
      width='fit-content'
    >
      <Stack direction='column'>
        <Typography color='white' fontSize={14}>
          {title}
        </Typography>
        <Typography color='white' fontSize={24} fontWeight={700} mt={1}>
          {value}
        </Typography>
      </Stack>
      <ReactApexChart
        options={{
          chart: { type: 'donut' },
          colors,
          legend: { show: false },
          dataLabels: { enabled: false },
        }}
        series={series}
        type='donut'
        width='120px'
      />
    </Box>
  )
}
