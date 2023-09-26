import {Hero} from "./ui/hero/hero.tsx";
import './home.scss'
import {Companies} from "./ui/companies/companies.tsx";
import AOS from 'aos';
import 'aos/dist/aos.css';
import {useEffect} from "react";
import {Residencies} from "./ui/residencies/residencies.tsx";
import {HomeValue} from "./ui/value/home-value.tsx";
import {Contacts} from "./ui/contacts/contacts.tsx";
import {GetStarted} from "./ui/get-started/get-started.tsx";
import {Footer} from "../../shared/ui/footer/footer.tsx";
export const HomePage = () => {
    useEffect(() => {
        AOS.init({duration: 2000})
        },[])
    return (
        <>
            <div className={'black-wrapper'}>
                <div className={'white-gradient'}></div>
                <Hero/>
                <Companies/>
            </div>
            <div className={'white-section'}>
                <Residencies/>
                <HomeValue/>
                <Contacts/>
                <GetStarted/>
                <Footer/>
            </div>
        </>
    )
}