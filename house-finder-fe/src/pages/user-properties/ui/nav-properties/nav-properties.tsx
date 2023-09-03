import './nav-properties.scss'
import {Route, Routes} from "react-router-dom";
import {SingleUserProperties} from "../single-user-properties/single-user-properties.tsx";
import {NavLink} from "../../../../core/navbar";
import {UsersPropertiesData} from "../../users-properties.tsx";
import {PropertyResponse} from "../../../../shared/model/property-response.ts";
export interface NavPropertiesProps {
    userProperties: UsersPropertiesData
}
export const NavProperties = ({userProperties} : NavPropertiesProps) => {
    const allProperties: PropertyResponse[] = [
        ...userProperties?.forSales || [],
        ...userProperties?.forRent || []
    ]
    return (
        <div className={'nav-container'}>
            <div className={'nav-top'}>
                <div className={'nav-link'}>
                    <NavLink url={'all-properties'}>
                        All Properties
                        <span className={'orange-text-small'}> ({allProperties.length}) </span>
                    </NavLink>
                </div>
                <div className={'nav-link'}>
                    <NavLink url={'sale'}>
                        For sale
                        <span className={'orange-text-small'}> ({userProperties?.forSales.length || 0}) </span>
                    </NavLink>
                </div>
                <div className={'nav-link'}>
                    <NavLink url={'rent'}>
                        For rent
                        <span className={'orange-text-small'}> ({userProperties?.forRent.length || 0}) </span>
                    </NavLink>
                </div>
            </div>
            <div className={'properties'}>
            <Routes>
                    <Route path={'/all-properties'} element={<SingleUserProperties properties={allProperties}/>}/>
                    <Route path={'/sale'} element={ <SingleUserProperties properties={userProperties?.forSales || []}/>}/>
                    <Route path={'/rent'} element={ <SingleUserProperties properties={userProperties?.forRent || []}/>}/>
            </Routes>
            </div>
        </div>
    );
};
