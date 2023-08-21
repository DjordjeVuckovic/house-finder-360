import './nav-properties.scss'
import {Route, Routes} from "react-router-dom";
import {AllUserProperties} from "../all-user-properties/all-user-properties.tsx";
import {NavLink} from "../../../../core/navbar";
export const NavProperties = () => {
    return (
        <div className={'nav-container'}>
            <div className={'nav-top'}>
                <div className={'nav-link'}>
                    <NavLink title={'All Properties' + '(0)'} url={'all-properties'}/>
                </div>
                <div className={'nav-link'}>
                    <NavLink title={'For rent' + '(0)'} url={'all-properties'}/>
                </div>
                <div className={'nav-link'}>
                    <NavLink title={'For sale' + '(0)'} url={'all-properties'}/>
                </div>
            </div>
            <div className={'properties'}>
            <Routes>
                    <Route path={'/all-properties'} element={<AllUserProperties />}/>
            </Routes>
            </div>
        </div>
    );
};
