import "./sign-in.scss"
import {BiLogoFacebookCircle} from "react-icons/bi";
import {AiFillGoogleCircle} from "react-icons/ai";
import React, {useEffect, useState} from "react";
import {Box, Modal, Typography} from "@mui/material";
const modalStyle = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 500,
    bgcolor: '#131010',
    borderRadius: '16px',
    boxShadow: 24,
    p: 4,
    color: 'white'
};

export const SignInPage = () => {
    const [animateCircles, setAnimateCircles] = useState(false);
    const [animateForm, setAnimateForm] = useState(false);
    const [open, setOpen] = React.useState(false);
    const handleOpen = ($event) => {
        $event.preventDefault();
        setOpen(true);
    }
    const handleClose = () => setOpen(false);
    useEffect(() => {
        handleAnimationStart();
    }, []);
    const handleAnimationStart = () => {
        setAnimateCircles(true);
        setAnimateForm(true);
    };
    return (
        <div className={`container-sign ${animateCircles ? 'animate-circles' : ''}`}>
            <div className={`background ${animateCircles ? 'animate-circles' : ''}`}>
                <div className="shape"></div>
                <div className="shape"></div>
            </div>
            <form className={`sign-in-form ${animateForm ? 'animate-form' : ''}`}>
                <h3>Sign In</h3>
                <label htmlFor="username">Username</label>
                <input type="text" placeholder="Email or Phone" id="username"/>
                <label htmlFor="password">Password</label>
                <input type="password" placeholder="Password" id="password"/>
                <button className={'btn'}>Log In</button>
                <button className={'forgot-link'} onClick={handleOpen}>Forgot your password?</button>
                <div className="social">
                    <div className="go icon"><AiFillGoogleCircle color={'#4066ff'} size={20}/>Google</div>
                    <div className="fb icon"><BiLogoFacebookCircle color={'#4066ff'} size={20}/>Facebook</div>
                </div>
                <Modal
                    open={open}
                    onClose={handleClose}
                    aria-labelledby="modal-modal-title"
                    aria-describedby="modal-modal-description"
                >
                    <Box sx={modalStyle}>
                        <Typography id="modal-modal-title" variant="h6" component="h2">
                            Forgot your password?
                        </Typography>
                        <Typography id="modal-modal-description" sx={{ mt: 2 }}>
                            Enter your email address and we'll send you a link to set your password.
                        </Typography>
                        <input type="text" placeholder="Email" id="username"/>
                        <button className={'btn'}>Send</button>
                    </Box>
                </Modal>
            </form>

        </div>
    );
};
