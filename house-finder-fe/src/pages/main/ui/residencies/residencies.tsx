import './residencies.scss'
import { useInfiniteQuery } from 'react-query'
import { fetchPropertiesPaginate } from '../../../../shared/services/property.service.ts'
import { Fragment } from 'react'
import { CustomLoader } from '../../../../core/custom-loader/custom-loader.tsx'
import { PropertyCard } from '../../../../shared/properties/property-card/property-card.tsx'
import { PropertyResponse } from '../../../../shared/model/property-response.ts'
import { SwiperSlider } from '../../../../shared/ui/swiper/swiper-slider.tsx'
export const Residencies = () => {
  const { data, isError, isLoading, fetchNextPage, hasNextPage } =
    useInfiniteQuery('properties', fetchPropertiesPaginate, {
      getNextPageParam: (lastPage, _) => {
        return lastPage.hasNextPage ? lastPage.currentPage + 1 : false
      },
    })
  if (isLoading) {
    return <CustomLoader />
  }

  if (isError) {
    return <div>Error fetching</div>
  }
  return (
    <section className={'r-wrapper'}>
      <div className={'padding-base inner-width r-container'}>
        <div className={'r-head flex-col-start'}>
          <span
            className={'orange-text'}
            data-aos='fade-right'
            data-aos-duration='3500'
          >
            Best Choices
          </span>
          <span
            className={'primary-text'}
            data-aos='fade-left'
            data-aos-duration='3500'
          >
            Popular Residencies
          </span>
        </div>
        <SwiperSlider fetchMore={fetchNextPage} hasMore={hasNextPage}>
          {data.pages.map((page, i) => (
            <Fragment key={i}>
              {page.data.map((property: PropertyResponse) => (
                <div key={property.id}>
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
                    theme={'light'}
                  />
                </div>
              ))}
            </Fragment>
          ))}
        </SwiperSlider>
      </div>
    </section>
  )
}
