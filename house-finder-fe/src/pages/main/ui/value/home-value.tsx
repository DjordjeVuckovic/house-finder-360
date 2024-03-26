import 'react-accessible-accordion/dist/fancy-example.css'
import valueImage from '../../../../assets/pictures/value.png'
import './home-value.scss'
import {
  Accordion,
  AccordionItem,
  AccordionItemButton,
  AccordionItemHeading,
  AccordionItemPanel,
} from 'react-accessible-accordion'
import { homeValueData } from './home-value.data.tsx'
import { MdOutlineArrowDropDown } from 'react-icons/md'
export const HomeValue = () => {
  return (
    <section className={'value-wrapper'}>
      <div className={'padding-base inner-width flex-center value-container'}>
        <div className={'value-left'}>
          <div
            className={'image-container'}
            data-aos='fade-up'
            data-aos-duration='3000'
          >
            <img src={valueImage} alt={'home-value'} />
          </div>
        </div>

        <div className={'flex-col-start value-right'}>
          <span
            className={'orange-text'}
            data-aos='fade-left'
            data-aos-duration='3000'
          >
            Our Value
          </span>
          <span
            className={'primary-text'}
            data-aos='fade-right'
            data-aos-duration='3000'
          >
            Value We Give to You <span className={'orange-text-large'}>.</span>
          </span>
          <span
            className={'secondary-text'}
            data-aos='fade-right'
            data-aos-duration='3000'
          >
            We always ready to help by providing the best services for you.
            <br />
            We believe a good place to live can make your life better.
          </span>
          <ValueAccordion />
        </div>
      </div>
    </section>
  )
}
const ValueAccordion = () => {
  return (
    <Accordion
      allowMultipleExpanded={false}
      preExpanded={[0]}
      className={'value-accordion'}
      data-aos='fade-down'
      data-aos-duration='3500'
    >
      {homeValueData.map((item) => {
        return (
          <AccordionItem
            className={`v-accordion-item expanded`}
            key={item.id}
            uuid={item.id}
          >
            <AccordionItemHeading>
              <AccordionItemButton className={'accordion-button'}>
                <div className={'flex-center value-icon'}>{item.icon}</div>
                <span className={'value-primary-text'}>{item.heading}</span>
                <div className={'flex-center value-icon'}>
                  <MdOutlineArrowDropDown size={25} />
                </div>
              </AccordionItemButton>
            </AccordionItemHeading>
            <AccordionItemPanel>
              <p className={'secondary-text'}>{item.detail}</p>
            </AccordionItemPanel>
          </AccordionItem>
        )
      })}
    </Accordion>
  )
}
