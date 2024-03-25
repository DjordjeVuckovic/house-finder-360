import CountUp from 'react-countup'
import './stats.scss'
export const Stats = () => {
  return (
    <div className={'flex-center stats'}>
      <div className={'flex-col-center stat'}>
        <span className={'stat-info'}>
          <CountUp start={5000} end={9000} duration={4} />
          <span className={'orange'}>+</span>
        </span>
        <span className={'secondary-text'}>Premium Products</span>
      </div>
      <div className={'flex-col-center stat'}>
        <span className={'stat-info'}>
          <CountUp start={2000} end={5000} duration={4} />
          <span className={'orange'}>+</span>
        </span>
        <span className={'secondary-text'}>New apartments this month</span>
      </div>
      <div className={'flex-col-center stat'}>
        <span className={'stat-info'}>
          <CountUp start={0} end={1000} duration={4} />
          <span className={'orange'}>+</span>
        </span>
        <span className={'secondary-text'}>Happy customers</span>
      </div>
    </div>
  )
}
