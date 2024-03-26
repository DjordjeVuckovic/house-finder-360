import { create } from 'zustand'
import { City } from '../../core/search/model/city.ts'
import { persist } from 'zustand/middleware'
import { createJSONStorage } from 'zustand/middleware'

interface PropertyState {
  selectedCity: City | null
  setSelectedCity: (city: City) => void
}

export const usePropertyStore = create<PropertyState>()(
  persist(
    (set) => ({
      selectedCity: null,
      setSelectedCity: (city: City) =>
        set((state) => ({ ...state, selectedCity: city })),
    }),
    {
      name: 'selected-property',
      storage: createJSONStorage(() => localStorage),
    }
  )
)
