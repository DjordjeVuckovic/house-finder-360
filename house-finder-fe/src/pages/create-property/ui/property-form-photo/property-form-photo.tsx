import house from "../../../../assets/pictures/residential.png";
import './property-form-photo.scss'
export const PropertyFormPhoto = ({totalSteps,activeStep,onChangeStep}) => {
    return (
        <div className="property-form-photo">
            {/*<div className="circle-small" />*/}
            <img src={house} alt="house" className="property-image" loading="lazy" />
            <div className="step-counter">
                {Array.from({ length: totalSteps}, (_, index) => (
                    <div
                        key={index}
                        className={`step-circle ${index === activeStep ? "active" : ""}`}
                        onClick={() => onChangeStep(index)}
                    >
                        {index + 1}
                    </div>
                ))}
            </div>
        </div>
    );
};
