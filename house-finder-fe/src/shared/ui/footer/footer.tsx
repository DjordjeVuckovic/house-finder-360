import logo from "../../../assets/logo.png";
import './footer.scss'
export const Footer = () => {
    return (
        <div className={'inner-width padding-base footer-wrapper'}>
            <div className={'footer-container'}
                 data-aos="fade-right"
                 data-aos-duration="2000">
                <div className={'flex-col-start logo-footer'}>
                    <img src={logo} alt={'logo'} className={'logo-footer__img'}/>
                    <div className={'white-text'}>Our vision is to make all people</div>
                    <div className={'white-text'}>the best place to live for them <span className={'orange-text'}> .</span></div>
                </div>
                <div className={'flex-col-start padding-base'}>
                    <div className={'orange-text-md'}>Information</div>
                    <div>Sutjeska 4, Novi Sad</div>
                    <div className={'flex-space g-07'}>
                        <div className={'primary-text-small'}>Property</div>
                        <br/>
                        <div className={'primary-text-small'}>Services</div>
                        <br/>
                        <div className={'primary-text-small'}>Products</div>
                        <br/>
                        <div className={'primary-text-small'}>Abouts us</div>
                    </div>
                </div>
            </div>
        </div>
    );
};
