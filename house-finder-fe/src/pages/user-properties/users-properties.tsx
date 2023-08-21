import {Typography} from "@mui/material";
import {CustomButton} from "../../shared/ui/buttons";
import {Add} from "@mui/icons-material";
import {Route, Routes, useNavigate} from "react-router-dom";
import "./user-properties.scss";
import {NavProperties} from "./ui/nav-properties/nav-properties.tsx";

export const UsersProperties = () => {
    const navigate = useNavigate()
    return (
        <div className={'padding-base inner-width rental-container'}>
            <div className={'flex-space'}>
                <Typography color="#ffffff" fontSize={32} fontWeight={700} mt={1}>
                    Your Properties
                </Typography>
                <CustomButton title="Add a property"
                              handleClick={()=> navigate('/create-property')}
                              bgColor={'linear-gradient(97.05deg, #4066ff 3.76%, #2949c6 100%)'}
                              color={'#ffffff'}
                              icon={<Add/>}/>
            </div>
            <Routes>
                <Route path="*" element={<NavProperties />}/>
            </Routes>
        </div>
    );
};
