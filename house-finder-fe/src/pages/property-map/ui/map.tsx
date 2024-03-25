import { GoogleMap, useLoadScript, MarkerF } from '@react-google-maps/api'
import { PropertyResponse } from '../../../shared/model/property-response.ts'
import { CustomLoader } from '../../../core/custom-loader/custom-loader.tsx'
import { useMemo } from 'react'

const containerStyle = {
  width: '50%',
  height: '100%',
}
const API_KEY = import.meta.env.VITE_GOOGLE_MAP_KEY
export const Map = ({
  properties,
  center,
}: {
  properties: PropertyResponse[]
  center?: { lat: number; lng: number }
}) => {
  const { isLoaded } = useLoadScript({
    googleMapsApiKey: API_KEY,
  })
  const mapCenter = useMemo(() => {
    return center
      ? center
      : {
          lat: 45.2542,
          lng: 19.811541,
        }
  }, [center])
  console.log(properties)
  const onLoad = (_: google.maps.Map) => {
    console.log('lll')
  }
  return (
    <>
      {!isLoaded ? (
        <CustomLoader />
      ) : (
        <GoogleMap
          mapContainerStyle={containerStyle}
          center={mapCenter}
          zoom={12}
          onLoad={onLoad}
          id={'google-maps'}
        >
          <PropertyMarkers properties={properties} />
        </GoogleMap>
      )}
    </>
  )
}
const PropertyMarkers = ({ properties }) => {
  return properties.map((property: PropertyResponse) => (
    <MarkerF
      key={property.id}
      position={{
        lat: property.address.streetLatitude,
        lng: property.address.streetLongitude,
      }}
    />
  ))
}
