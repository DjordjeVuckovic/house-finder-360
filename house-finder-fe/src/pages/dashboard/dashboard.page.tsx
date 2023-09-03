import {Box, Stack, Typography} from "@mui/material";
import {PieChart} from "../../shared/ui/charts/PieChart.tsx";
import {TotalRevenue} from "../../shared/ui/charts/TotalRevenue.tsx";
import {PropertyReferrals} from "../../shared/ui/charts/PropertyReferrals.tsx";


export const DashboardPage = () => {
  return (
      <div className={'inner-width'}>
        <Box m="5px" p={'1rem'}>
          <Typography fontSize={25} fontWeight={700}
          color="#f5f8f2"
          >
            Dashboard
          </Typography>
          <Box mt="20px" display="flex" flexWrap="wrap" gap={4}>
            <PieChart
              title="Properties for Sale"
              value = {684}
              series = {[75,25]}
              colors={['#475be8','#e4e8ef']}
            />
            <PieChart
              title="Properties for Rent"
              value = {550}
              series = {[60,40]}
              colors={['#475ae8','#e4e8ef']}
            />
            <PieChart
              title="Total customers"
              value = {5684}
              series = {[75,25]}
              colors={['#475be8','#e4e8ef']}
            />
            <PieChart
              title="Properties for Cities"
              value = {700}
              series = {[75,25]}
              colors={['#475be8','#e4e8ef']}
            />
          </Box>
          <Stack mt="25px" width="100%" gap={4} direction={{
            xs:'column',
            lg:'row'
          }}
          >
            <TotalRevenue/>
            <PropertyReferrals/>
          </Stack>
        </Box>
      </div>
  );
}