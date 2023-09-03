
import './buttons.scss'
import {ButtonWithIconProps} from "./button-props.ts";
export const ButtonWithIcon = ({   color,
                                   bgColor,
                                   width,
                                   icon: Icon,
                                   children,
                                   onClick,
                                   iconFirst = true,
                                   type = 'button' } : ButtonWithIconProps) => {
    return (
        <button
            className={`button-base-icon`}
            style={{ background: bgColor, color: color, width: width}}
            onClick={onClick}
            type={type}
        >
            {iconFirst
                ?
                <>
                    {Icon && <Icon color={color} size={20}/>}
                    {children}
                </>
                :
                <>
                    {children}
                    {Icon && <Icon color={color} size={20}/>}
                </>
            }
        </button>
    );
};