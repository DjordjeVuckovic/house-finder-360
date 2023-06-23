import {Add} from '@mui/icons-material'
import {useList} from '@pankod/refine-core'
import {Typography, Box, Stack} from "@pankod/refine-mui";
import {useNavigate} from "@pankod/refine-react-router-v6";

import {PropertyCard, CustomButton} from "../components";

export const AllProperties = () => {
  const navigate = useNavigate()
  return (
    <Box>
      <Stack direction="row"
             justifyContent="space-between"
             alignItems="center"
      >
        <Typography color="#11142d" fontSize={26} fontWeight={700} mt={1}>
          All Properties
        </Typography>
        <CustomButton title="Add Property"
                      handleClick={()=> navigate('/properties/create')}
                      bgColor="#475be8"
                      color="#fcfcfc"
                      icon={<Add/>}
        />
      </Stack>
    </Box>
  );
}