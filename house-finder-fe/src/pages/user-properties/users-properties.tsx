import { Typography } from '@mui/material'
import { CustomButton } from '../../shared/ui/buttons'
import { Add } from '@mui/icons-material'
import { Route, Routes, useNavigate } from 'react-router-dom'
import './user-properties.scss'
import { NavProperties } from './ui/nav-properties/nav-properties.tsx'
import { useQuery } from 'react-query'
import { getUserProperties } from '../../shared/services/property.service.ts'
import { useUserPayload } from '../../auth/use-get-user.ts'
import { CustomLoader } from '../../core/custom-loader/custom-loader.tsx'
import { PropertyResponse } from '../../shared/model/property-response.ts'
export interface UsersPropertiesData {
  forRent: PropertyResponse[]
  forSales: PropertyResponse[]
}
export const UsersProperties = () => {
  const navigate = useNavigate()
  const user = useUserPayload()
  const userId = user?.id
  const { data, isLoading } = useQuery({
    queryKey: ['user-properties', userId],
    queryFn: async () => {
      const properties = await getUserProperties(user.id)
      const usersPropertiesData: UsersPropertiesData = properties.reduce(
        (accumulator, property) => {
          switch (property.purpose) {
            case 'Rent':
              accumulator.forRent.push(property)
              break
            case 'Sale':
              accumulator.forSales.push(property)
              break
          }
          return accumulator
        },
        { forRent: [], forSales: [] }
      )
      return usersPropertiesData
    },
    enabled: !!userId,
  })
  if (isLoading) {
    return <CustomLoader />
  }
  console.log(data)
  return (
    <div className={'padding-base inner-width rental-container'}>
      <div className={'flex-space'}>
        <Typography color='#ff922d' fontSize={32} fontWeight={700} mt={1}>
          Your Properties
        </Typography>
        <CustomButton
          title='Add a property'
          handleClick={() => navigate('/create-property')}
          bgColor={'linear-gradient(97.05deg, #4066ff 3.76%, #2949c6 100%)'}
          color={'#ffffff'}
          icon={<Add />}
        />
      </div>
      <Routes>
        <Route path='*' element={<NavProperties userProperties={data} />} />
      </Routes>
    </div>
  )
}
