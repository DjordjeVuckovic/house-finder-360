import {Hero} from "./ui/hero/hero.tsx";
import './main.scss'
import {Companies} from "./ui/companies/companies.tsx";
import AOS from 'aos';
import 'aos/dist/aos.css';
import {useEffect} from "react";
export const MainPage = () => {
    useEffect(() => {
        AOS.init({duration: 2000})
        },[])
    return (
        <div>
            <Hero/>
            <Companies/>
        </div>
    )
}