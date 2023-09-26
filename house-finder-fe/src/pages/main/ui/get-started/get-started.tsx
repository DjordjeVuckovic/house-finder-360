import './get-started.scss'
import logo from "../../../../assets/logo.png";
export const GetStarted = () => {
    return (
        <div className={'inner-width get-started-wrapper padding-base'}
             data-aos="flip-up"
             data-aos-duration="1000">
            <div className={'flex-col-center get-started-container'}
                 data-aos="fade-down"
                 data-aos-duration="2000">
                <div className={'flex-center g-07'}>
                    <div className={'get-started-header'}>
                        Get started with
                    </div>
                    <img src={logo} alt={'logo'}/>
                </div>
                <div className={'flex-col-center'}>
                    <div>Subscribe and find your dream place
                        <span className={'orange-text'}> .</span>
                    </div>
                    <div>Find your residence soon <span className={'orange-text-small'}> !</span></div>
                </div>
                <button className={'get-started-btn'}>Get started</button>
            </div>
        </div>
    );
};
