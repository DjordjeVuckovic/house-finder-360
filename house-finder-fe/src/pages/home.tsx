import {useList} from "@pankod/refine-core";
import {
  PieChart,
  PropertyReferrals,
  TotalRevenue,
  PropertyCard,
} from "components";
import {Typography, Box, Stack} from "@pankod/refine-mui";

export const Home = () => {
  return (
    <Box m="5px">
      <Typography fontSize={25} fontWeight={700}
      color="#11143D"
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
  );
}