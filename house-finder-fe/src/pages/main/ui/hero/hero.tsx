import heroImage from "../../../../assets/pictures/hero-image.png"
import "./hero.scss"
import {Searchbar} from "../../../../core/search/searchbar.tsx";
import {useState} from "react";
import {City} from "../../../../core/search/model/city.ts";
import {Stats} from "../stats/stats.tsx";
export const Hero = () => {
    const [selectedCountry, setSelectedCountry] = useState<City | null>(null);

    const handleCityChange = (city: City): void => {
        setSelectedCountry(city);
    };
    const handleOnSearch = (): void => {
        console.log(selectedCountry)
    }
    return (
        <section className="hero-wrapper">
            <div className="padding-base inner-width hero-container">
                <div className="flex-col-start hero-left">
                    <div className="hero-title"
                         data-aos="fade-up"
                         data-aos-duration="3000">
                        <div className={'circle'}></div>
                        <h1>Discover <br/> Most Suitable <br/> Property</h1>
                    </div>
                    <div className="flex-col-start hero-description"
                         data-aos="fade-down"
                         data-aos-duration="3000">
                        <span className={'secondary-text'}>Find a variety of properties that suit you very easily</span>
                        <span className={'secondary-text'}>Forget all difficulties in finding a residence for you</span>
                    </div>
                    <Searchbar onSearch={handleOnSearch} onSearchChange={handleCityChange}/>
                    <Stats/>
                </div>
                <div className="hero-right">
                    <div className="image-container"
                         data-aos="fade-right"
                         data-aos-duration="3000">
                        <img src={heroImage} alt={'img'} loading='lazy'/>
                    </div>
                </div>
            </div>
        </section>
    );
};
