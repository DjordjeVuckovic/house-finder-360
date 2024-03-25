import { Map } from './ui/map.tsx'
import { fetchPropertiesByCity } from '../../shared/services/property.service.ts'
import { PropertyResponse } from '../../shared/model/property-response.ts'
import { usePropertyStore } from '../../shared/state/property.state.ts'
import { useQuery } from 'react-query'
import { CustomLoader } from '../../core/custom-loader/custom-loader.tsx'
import { PropertyCard } from '../../shared/properties/property-card/property-card.tsx'
import './properties-map.scss'
import { NoItems } from '../../core/no-items/no-items.tsx'
import houseImg from '../../assets/pictures/no-house.png'

export const PropertiesMapPage = () => {
  const { selectedCity } = usePropertyStore()
  const { data, isLoading } = useQuery(
    ['properties-by-city', selectedCity.city],
    () =>
      fetchPropertiesByCity(selectedCity.city, {
        currentPage: 1,
        pageSize: 500,
      }),
    {
      enabled: !!selectedCity,
    }
  )
  if (isLoading) {
    return <CustomLoader />
  }
  if (data.data.length === 0) {
    return (
      <NoItems
        imgSrc={houseImg}
        content={'This city currently has no properties.'}
        imgHeight={'200px'}
        imgWidth={'200px'}
        contentColor={'#4066ff'}
        position={'center'}
      />
    )
  }
  return (
    <div className={'properties-map-wrapper'}>
      <div className={'flex-wrap properties-map-container'}>
        <Map
          properties={data.data}
          center={{
            lng: selectedCity.lng,
            lat: selectedCity.lat,
          }}
        />
        {data.data.length === 0 ? (
          <NoItems
            imgSrc={houseImg}
            content={'This city currently has no properties.'}
            imgHeight={'200px'}
            imgWidth={'200px'}
            contentColor={'#4066ff'}
            position={'center'}
          />
        ) : (
          <PropertySearchList properties={data.data} />
        )}
      </div>
    </div>
  )
}
export interface PropertySearchList {
  properties: PropertyResponse[]
}
export const PropertySearchList = ({ properties }: PropertySearchList) => {
  return (
    <div className={'properties-grid'}>
      {properties.map((property) => (
        <PropertyCard
          title={property.title}
          address={property.address.country}
          area={property.area}
          bathrooms={property.bathroomsNumber}
          bedrooms={property.bedroomsNumber}
          image={property.propertyImageUris[0]}
          price={property.price}
          key={property.id}
          purpose={property.purpose}
          description={property.description}
          theme={'dark'}
        />
      ))}
    </div>
  )
}
