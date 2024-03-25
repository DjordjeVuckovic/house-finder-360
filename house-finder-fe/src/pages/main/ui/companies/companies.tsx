import './companies.scss'
import c1 from '../../../../assets/pictures/equinix.png'
import c2 from '../../../../assets/pictures/tower.png'
import c3 from '../../../../assets/pictures/realty.png'
import c4 from '../../../../assets/pictures/prologis.png'
import 'aos/dist/aos.css'
export const Companies = () => {
  return (
    <section className={'companies-wrapper'}>
      <div className='padding-base flex-center companies-container'>
        <img
          src={c1}
          alt={'logo'}
          data-aos='fade-right'
          data-aos-duration='3500'
        />
        <img
          src={c2}
          alt={'logo'}
          data-aos='fade-right'
          data-aos-duration='3500'
        />
        <img
          src={c3}
          alt={'logo'}
          data-aos='fade-left'
          data-aos-duration='3500'
        />
        <img
          src={c4}
          alt={'logo'}
          data-aos='fade-left'
          data-aos-duration='3500'
        />
      </div>
    </section>
  )
}
