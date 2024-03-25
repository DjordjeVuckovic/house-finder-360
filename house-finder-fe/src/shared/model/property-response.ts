import { AddressResponse } from './address.ts'

export interface PropertyResponse {
  id: string
  title: string
  price: number
  address: AddressResponse
  bedroomsNumber: string
  bathroomsNumber: number
  area: 56
  propertyType: string
  purpose: PurposeType
  propertyImageUris: string[]
  description: string
}
type PurposeType = 'Sale' | 'Rent'
