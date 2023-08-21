import {Typography} from "@mui/material";
import './../style/property-form.scss';
import {InputWithSymbol} from "../../../../shared/ui/forms";
import {ButtonWithIcon,SubmitButton} from "../../../../shared/ui/buttons";
import {MdNavigateBefore} from "react-icons/md";
import {BsFillHouseAddFill} from "react-icons/bs";
export const DeterminatePriceStep = ({
                                         type,
                                         register,
                                         errors,
                                         onBack,
                                         onFinishHandler,
                                         handleSubmit,
                                         isLoading}) => {
    return (
        <form style={{
            display: 'flex',
            flexDirection: 'column',
            gap: '1.2rem'
        }}
              onSubmit={handleSubmit(onFinishHandler)}
        >
            <Typography fontSize={25} fontWeight={700} color="#ffffff">
                {type} a Property <span className={'step-count'}>(set price)</span>
            </Typography>
            <InputWithSymbol
                key={'price'}
                label={'Enter property price (euro)'}
                width={'100%'}
                error={errors.price?.message}
                register={register('price', {
                    valueAsNumber: true,
                    required: {
                        value: true,
                        message: 'Property price is required'
                    }})}
                type={'number'}
                placeholder={'Enter a price'}
                symbol={'€'}
            />
            <div className={'btn-group'}>
                <ButtonWithIcon bgColor={'linear-gradient(97.05deg, #4066ff 3.76%, #2949c6 100%)'}
                                color={'#f5f8f2'}
                                icon={MdNavigateBefore}
                                width={'20%'}
                                onClick={onBack}>
                    Back
                </ButtonWithIcon>
                <SubmitButton color={'#f5f8f2'}
                              icon={BsFillHouseAddFill}
                              width={'20%'}
                              iconColor={'#ff922d'}
                              isLoading={isLoading}
                              type={'submit'}
                              disabled={false}>
                    {isLoading ? 'Loading...' : 'Finish'}
                </SubmitButton>
            </div>
        </form>
    );
};
