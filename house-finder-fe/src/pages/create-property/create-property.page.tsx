import './property-form.scss';
import {PropertyFormPhoto} from "./ui/property-form-photo/property-form-photo.tsx";
import {PropertyFormStep1} from "./ui/property-form-step-1/property-form-step-1.tsx";
import {useState} from "react";
import {PropertyFormStep2} from "./ui/property-form-step-2/property-form-step-2.tsx";
import {useForm} from "react-hook-form";
import {SaleProperty, SalePropertyRequest} from "./model/property.ts";
import {UploadFilesStep} from "./ui/upload-files-step/upload-files-step.tsx";
import {DeterminatePriceStep} from "./ui/determinate-price-step/determinate-price-step.tsx";
import {useMutation} from "react-query";
import {createSaleProperty} from "../../shared/services/property.service.ts";
import {mapSalePropertyToRequest} from "./utils/property.mapper.ts";
import {useToast} from "../../shared/toast-messages/use-toast.ts";
import {AxiosError} from "axios";
import {useNavigate} from "react-router-dom";
import {useFileStore} from "./state/file.store.ts";
import {useUserPayload} from "../../auth/use-get-user.ts";
import {handleError} from "../../utils/handle-error.ts";

export const CreatePropertyPage = () => {
    const {
        register,
        handleSubmit,
        formState: { errors },
        setValue,
        getValues
    } = useForm<SaleProperty>({mode: 'onTouched'})

    const {showToast} = useToast()

    const { files, clearStore} = useFileStore();
    const user = useUserPayload()

    const navigate = useNavigate()

    const mutation = useMutation(createSaleProperty, {
        onError: (error: AxiosError) => {
            showToast(handleError(error), 'error');
        },
        onSuccess: _ => {
            showToast('You are successfully created property!', 'success');
            clearStore()
            navigate('/rental-manager/all-properties')
        }
    });
    const transformToFormData = (property: SalePropertyRequest) => {
        const formData = new FormData();
        files.forEach((file, index) => {
            formData.append(`photos[${index}]`, file);
        });
        formData.append('property', JSON.stringify(property))
        return formData
    }
    const totalSteps = 4;
    const [activeStep, setActiveStep] = useState(0);
    const handleNext = () => {
        console.log(user.id)
        setActiveStep(prev => prev + 1);
    };
    const handlePrev = () => {
        setActiveStep(prev => prev - 1);
    }
    const onSubmitFormStep = () => {
        handleNext()
    }
    const onSubmitFinalSubmit = (data: SaleProperty) => {
        console.log(data)
        const request = mapSalePropertyToRequest(data)
        const property = {...request,userId: user.id} as SalePropertyRequest
        mutation.mutate(transformToFormData(property))
    }
    const onChangeStep = (step: number) => {
        setActiveStep(step);
    };

    return (
            <div className={'padding-base inner-width grid-form'}>
                <div className={'form-create'}>
                    {activeStep === 0 && <PropertyFormStep1 type={'Create'}
                                                            onFinishHandler={onSubmitFormStep}
                                                            register={register}
                                                            errors={errors}
                                                            handleSubmit={handleSubmit}
                                                            getValues={getValues}/>
                    }
                    {activeStep === 1 && <PropertyFormStep2 type={'Create'}
                                                            onFinishHandler={onSubmitFormStep}
                                                            register={register}
                                                            errors={errors}
                                                            handleSubmit={handleSubmit}
                                                            setValue={setValue}
                                                            getValues={getValues}
                                                            onBack={handlePrev}/>
                    }
                    {activeStep === 2 && <UploadFilesStep type={'Create'}
                                                          onBack={handlePrev}
                                                          onNext={handleNext} />
                    }
                    {activeStep === 3 && <DeterminatePriceStep  type={'Create'}
                                                                errors={errors}
                                                                register={register}
                                                                handleSubmit={handleSubmit}
                                                                onFinishHandler={onSubmitFinalSubmit}
                                                                onBack={handlePrev}
                                                                isLoading={mutation.isLoading}
                    />
                    }
                </div>
                <PropertyFormPhoto activeStep={activeStep}
                                   totalSteps={totalSteps}
                                   onChangeStep={onChangeStep}/>
            </div>
    );
};
