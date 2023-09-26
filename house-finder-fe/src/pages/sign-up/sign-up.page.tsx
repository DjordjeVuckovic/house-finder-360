import {useEffect, useState} from "react";
import "./sign-up.scss"
import {CircularProgress, FormControl} from "@mui/material";
import {useForm} from "react-hook-form";
import {SignUpForm, SignUpRequest} from "../../auth/auth.model.ts";
import {FieldError} from "../../shared/ui/errors/FieldError.tsx";
import {useMutation} from "react-query";
import {handleError} from "../../utils/handle-error.ts";
import useAuthStore from "../../auth/auth-store.ts";
import {useToast} from "../../shared/toast-messages/use-toast.ts";
import {useNavigate} from "react-router-dom";
import {AxiosError} from "axios";
import {signUp} from "../../auth/auth-service.ts";
import {AiOutlineUserAdd} from "react-icons/ai";

export const SignUpPage = () => {
    const [animateCircles, setAnimateCircles] = useState(false);
    const [animateForm, setAnimateForm] = useState(false);
    useEffect(() => {
        handleAnimationStart();
    }, []);
    const handleAnimationStart = () => {
        setAnimateCircles(true);
        setAnimateForm(true);
    };

    const {
        register,
        handleSubmit,
        watch,
        formState: { errors },
    } = useForm<SignUpForm>({mode: 'onTouched'})

    const { setAccessToken} = useAuthStore()
    const {showToast} = useToast()
    const navigate = useNavigate()

    const password = watch("password");

    const mutation = useMutation(signUp, {
        onError: (error: AxiosError) => {
            showToast(handleError(error), 'error');
        },
        onSuccess: (data: {token: string}) => {
            console.log(data)
            showToast('You are successfully sign up!', 'success');
            setAccessToken(data.token)
            navigate('/rental-manager/all-properties')
        }
    });

    const handleSignUp = (data: SignUpForm) => {
        const request: SignUpRequest = {
            email: data.email,
            firstName: data.phone,
            lastName: data.lastName,
            password: data.password,
            phone: data.phone,
            role: 'user'
        }
        mutation.mutate(request)
    }
    return (
        <div className={`container-sign-up ${animateCircles ? 'animate-circles-up' : ''}`}>
            <div className={`background-up ${animateCircles ? 'animate-circles-up' : ''}`}>
                <div className="shape-up"></div>
                <div className="shape-up"></div>
            </div>
            <form className={`sign-up-form ${animateForm ? 'animate-form' : ''}`}
                  onSubmit={handleSubmit(handleSignUp)}>
                <h3 className={'white-text'}>Sign Up</h3>
                <FormControl>
                    <label htmlFor="email">Email</label>
                    <input type="text"
                           placeholder="Email"
                           id="email"
                           {...register('email', {
                            required: {
                                value: true,
                                message: 'Email is required'
                            },
                            pattern: {
                               value: /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i,
                               message: 'Invalid email address'
                            }
                           })}
                    />
                    {errors.email?.message && (
                        <FieldError error={errors.email.message}/>
                    )}
                </FormControl>
                <FormControl>
                    <label htmlFor="phone">Phone</label>
                    <input type="text"
                           placeholder="Phone"
                           id="phone"
                           {...register('phone', {
                                required: {
                                    value: true,
                                    message: 'Phone is required'
                                }
                           })}
                    />
                    {errors.phone?.message && (
                        <FieldError error={errors.phone.message}/>
                    )}
                </FormControl>
                <div className={'row'}>
                    <div className={'input-col'}>
                        <FormControl>
                            <label htmlFor="first-name">First Name</label>
                            <input type="text"
                                   placeholder="First Name"
                                   id="first-name"
                                   {...register('firstName', {
                                        required: {
                                            value: true,
                                            message: 'First name is required'
                                        }
                                   })}
                            />
                            {errors.firstName?.message && (
                                <FieldError error={errors.firstName.message}/>
                            )}
                        </FormControl>
                    </div>
                    <div className={'input-col'}>
                        <FormControl>
                            <label htmlFor="last-name">Last Name</label>
                            <input type="text"
                                   placeholder="Last Name"
                                   id="last-name"
                                   {...register('lastName', {
                                        required: {
                                            value: true,
                                            message: 'Last name is required'
                                        }
                                   })}
                            />
                            {errors.lastName?.message && (
                                <FieldError error={errors.lastName.message}/>
                            )}
                        </FormControl>
                    </div>
                </div>
                <FormControl>
                    <label htmlFor="password">Password</label>
                    <input type="password"
                           placeholder="Password"
                           id="password"
                           {...register('password', {
                                required: "Password is required",
                                validate: {
                                    nonAlphanumeric: value => /\W|_/.test(value) || "Passwords must have at least one non alphanumeric character",
                                    digit: value => /\d/.test(value) || "Passwords must have at least one digit (0-9)",
                                    uppercase: value => /[A-Z]/.test(value) || "Passwords must have at least one uppercase (A-Z)"
                                }
                           })}
                    />
                    {errors.password?.message && (
                        <FieldError error={errors.password.message}/>
                    )}
                </FormControl>
                <FormControl>
                    <label htmlFor="password-confirm">Confirm Password</label>
                    <input type="password"
                           placeholder="Confirm Password"
                           id="password-confirm"
                           {...register('confirmPassword', {
                            required: "Confirm password is required",
                            validate: value => value === password || "Passwords must match"
                            })}
                    />
                    {errors.confirmPassword?.message && (
                        <FieldError error={errors.confirmPassword.message}/>
                    )}
                </FormControl>
                <button
                    type={'submit'}
                    className={'btn-sign'}
                    disabled={mutation.isLoading}>
                    Sign Up
                    {!mutation.isLoading
                        ? (<span className={'sign-btn-icon'}><AiOutlineUserAdd size={25}/></span>)
                        : (<span className={'sign-btn-icon'}><CircularProgress size={25} style={{color: "white"}} /></span>)
                    }
                </button>
                <p className={'terms'}>
                    By submitting, I accept House finder <a href={'#'}>terms of use.</a>
                </p>
            </form>
        </div>
    );
};
