import './property-card.scss'
import {PropertyCardProps} from "../properties-shared.props.ts";
import {truncateString} from "../../utils/text-utils.ts";
import {RiHeart2Fill} from "react-icons/ri";
import {BsDoorOpen} from "react-icons/bs";
import {TfiRulerAlt} from "react-icons/tfi";
import {BiBath} from "react-icons/bi";
export const PropertyCard = (props : PropertyCardProps) => {
    const color = props.theme === "light" ? '#000000' : '#ffffff'
    return (
        <div className={'flex-col-start card-container'}>
            <div className={'c-image'}>
                <div className={'purpose'}>For {props.purpose}</div>
                <div className={'p-heart'}>
                    <RiHeart2Fill size={20}
                                  color={'grey'}
                                  className={'heart-icon'}/>
                </div>
                <img src={props.image} alt='property-image'/>
            </div>
            <span className={'orange-text card-price'}>
                <span className={'orange-text-small p-price-symbol'}>€</span>
                &nbsp;
                <span className={'p-price'}>{props.price}</span>
            </span>
            <span className={'primary-text p-title'}>{props.title}</span>
            <span style={{color: color}} className={'p-description'}>
                {truncateString(props.description,40)}
            </span>
            <div className={'p-card-icon-group'}>
                <div className={'p-card-icon'}>
                    <BsDoorOpen color={'#7c4700'} size={20}/>
                    <span className={'p-card-icon__text'}>{props.bedrooms}</span>
                </div>
                <div className={'p-card-icon'}>
                    <BiBath color={'#4066ff'} size={20}/>
                    <span className={'p-card-icon__text'}>{props.bathrooms}</span>
                </div>
                <div className={'p-card-icon'}>
                    <TfiRulerAlt color={'rgb(50,205,50)'} size={20}/>
                    <span className={'p-card-icon__text'}>{props.area} m²</span>
                </div>
            </div>
        </div>
    );
};
