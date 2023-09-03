import cImage from "../../../../assets/pictures/contact.jpg"
import './contacts.scss'
export const Contacts = () => {
    return (
        <section className={'c-wrapper'}>
            <div className={'padding-base inner-width flex-center c-container'}>
                <div className={'c-left flex-col-start'}>
                    <span className={'orange-text'}
                          data-aos="fade-right"
                          data-aos-duration="3000">Support Options & Contact Us</span>
                    <span className={'primary-text'}
                          data-aos="fade-left"
                          data-aos-duration="3000">Easy to contact us <span className={'orange-text-large'}>.</span>
                    </span>
                    <span className={'secondary-text'}
                          data-aos="fade-right"
                          data-aos-duration="3000">
                        If you need help, we offer number of options for customer support.
                        <br/>
                        You can call, chat or message our support 24/7.
                    </span>

                </div>

                <div className={'c-right'}>
                    <div className={'image-container'}
                         data-aos="fade-down"
                         data-aos-duration="3000">
                        <img src={cImage} alt={'contact'}/>
                    </div>
                </div>
            </div>
        </section>
    );
};
