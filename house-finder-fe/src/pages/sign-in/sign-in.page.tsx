import "./sign-in.scss"
import {BiLogoFacebookCircle} from "react-icons/bi";
import React, {useEffect, useState} from "react";
import {Box, Modal, Typography} from "@mui/material";
import useAuthStore from "../../auth/auth-store.ts";
import {useForm} from "react-hook-form";
import {SignInRequest} from "../../auth/auth.model.ts";
import {FieldError} from "../../shared/ui/errors/FieldError.tsx";
import {FcGoogle} from "react-icons/fc";
import {logIn} from "../../auth/auth-service.ts";
import {useMutation} from "react-query";
import {useToast} from "../../shared/toast-messages/use-toast.ts";
import {AxiosError} from "axios";
import {useNavigate} from "react-router-dom";
import {handleError} from "../../utils/handle-error.ts";
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
    const { setAccessToken} = useAuthStore()
    const {showToast} = useToast()
    const navigate = useNavigate()
    const mutation = useMutation(logIn, {
        onError: (error: AxiosError) => {
            showToast(handleError(error), 'error');
        },
        onSuccess: (data: {token: string}) => {
            console.log(data)
            showToast('You are successfully sign in!', 'success');
            setAccessToken(data.token)
            navigate('/rental-manager/all-properties')
        }
    });
    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm<SignInRequest>({mode: 'onTouched'})
    const handleOpen = ($event: { preventDefault: () => void; }) => {
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

    const signIn = async (data: SignInRequest) => {
        mutation.mutate(data)
    }

    return (
        <div className={`container-sign ${animateCircles ? 'animate-circles' : ''}`}>
            <div className={`background ${animateCircles ? 'animate-circles' : ''}`}>
                <div className="shape"></div>
                <div className="shape"></div>
            </div>
            <form className={`sign-in-form ${animateForm ? 'animate-form' : ''}`} onSubmit={handleSubmit(signIn)}>
                <h3 className={'white-text'}>Sign In</h3>
                <label htmlFor="username" className={'white-text'}>Username</label>
                <input type="text"
                       placeholder="Email or Phone"
                       id="username"
                       {...register('emailOrPhone', {
                            required: {
                                value: true,
                                message: 'Email is required'
                            }
                       })}
                />
                {errors.emailOrPhone?.message && (
                    <FieldError error={errors.emailOrPhone.message}/>
                )}

                <label htmlFor="password" className={'white-text'}>Password</label>
                <input type="password"
                       placeholder="Password"
                       id="password"
                       autoComplete="new-password"
                       {...register('password', {
                           required: {
                            value: true,
                            message: 'Password is required'
                           }
                       })}
                />
                {errors.password?.message && (
                    <FieldError error={errors.password.message}/>
                )}
                <button type={'submit'}
                        className={'btn'}
                        disabled={mutation.isLoading}>
                    Log In
                </button>
                <button className={'forgot-link'} onClick={handleOpen}>Forgot your password?</button>
                <div className="social">
                    <div className="go icon"><FcGoogle size={25}/>Google</div>
                    <div className="fb icon"><BiLogoFacebookCircle color={'#4066ff'} size={25}/>Facebook</div>
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
                        <input type="text"
                               className={'input-base'}
                               placeholder="Email"
                               id="username"/>
                        <button className={'btn'}>Send</button>
                    </Box>
                </Modal>
            </form>

        </div>
    );
};
