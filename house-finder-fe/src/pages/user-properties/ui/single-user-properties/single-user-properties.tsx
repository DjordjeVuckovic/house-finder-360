import './all-user-properties.scss'
import { PropertyResponse } from '../../../../shared/model/property-response.ts'
import { PropertyCard } from '../../../../shared/properties/property-card/property-card.tsx'
import { Fragment } from 'react'
export interface SinglePropertiesProps {
  properties: PropertyResponse[]
}
export const SingleUserProperties = ({ properties }: SinglePropertiesProps) => {
  return (
    <div className={'all-user-properties'}>
      {properties.map((property) => (
        <Fragment key={property.id}>
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
        </Fragment>
      ))}
    </div>
  )
}
