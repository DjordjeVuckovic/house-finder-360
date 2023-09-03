import {
    Typography
} from "@mui/material";
import "../style/property-form.scss"
import {InputCore, InputWithSymbol} from "../../../../shared/ui/forms";
import {TextAreaBase} from "../../../../shared/ui/forms";
import {SingleSelect} from "../../../../shared/ui/selects";
import {SelectItem} from "../../../../shared/ui/selects/select-props.ts";
import {ButtonWithIcon} from "../../../../shared/ui/buttons";
import {MdOutlineNavigateNext} from "react-icons/md";
export const PropertyFormStep1 = ({type,register,handleSubmit,errors,onFinishHandler,getValues}) => {
    const typeMenuItems: SelectItem[] = [
        {value: 'Apartment', text: 'Apartment'},
        {value: 'Villa', text: 'Villa'},
        {value: 'House', text: 'House'},
        {value: 'Garage', text: 'Garage'}
    ]
    const registerItems: SelectItem[] = [
        {value: 'Register', text: 'Register'},
        {value: 'NotRegister', text: 'Not Register'},
        {value: 'PartialRegister', text: 'Partial Register'},
        {value: 'InRegistrationProcess', text: 'In RegistrationProcess'},
    ]
    const conditionItems: SelectItem[] = [
        {value: 'new', text: 'New'},
        {value: 'underConstruction', text: 'Under construction'},
        {value: 'renovated', text: 'Renovated'},
        {value: 'lux', text: 'Lux'},
        {value: 'old', text: 'Old'},
    ]
    const roomItems: SelectItem[] = [
        {value: '1', text: 'One'},
        {value: '1 1/2', text: 'One and a half'},
        {value: '2', text: 'Two'},
        {value: '2 1/2', text: 'Two and a half'},
        {value: '3', text: 'Three'},
        {value: '3 1/2', text: 'Three and a half'},
        {value: '4', text: 'Four'},
        {value: '4+', text: 'Four +'},
    ]
    const heatingItems: SelectItem[] = [
        {value: 'central', text: 'Central'},
        {value: 'noHeating', text: 'No Heating'},
        {value: 'gas', text: 'Gas'},
        {value: 'electricHeating', text: 'Electric Heating'},
        {value: 'other', text: 'Other'},
    ]
    const elevatorItems: SelectItem[] = [
        {value: 0, text: 'No Elevator'},
        {value: 1, text: '1'},
        {value: 2, text: '2'},
        {value: 3, text: '3'},
        {value: 4, text: '3 +'},
    ]
    const floorItems: SelectItem[] = [
        {value: 'ground', text: 'Ground Level'},
        {value: '1', text: '1. floor'},
        {value: '2', text: '2. floor'},
        {value: '3', text: '3. floor'},
        {value: '4', text: '4. floor'},
        {value: '5', text: '5. floor'},
        {value: '5+', text: '5. floor +'},
    ]
    const totalFloorItems: SelectItem[] = [
        {value: '1', text: '1 floor'},
        {value: '2', text: '2 floor'},
        {value: '3', text: '3 floor'},
        {value: '4', text: '4 floor'},
        {value: '5', text: '5 floor'},
        {value: '5+', text: '5 floor +'},
    ]
    const numberOfBathrooms: SelectItem[] = [
        {value: 1,text: '1'},
        {value: 2,text: '2'},
        {value: 3,text: '3'},
        {value: 4,text: '4'},
        {value: 5,text: '5'},
    ]
    const numberOfBalconies: SelectItem[] = [
        {value: 1,text: '1'},
        {value: 2,text: '2'},
        {value: 3,text: '3'},
        {value: 4,text: '4'},
        {value: 5,text: '5'},
    ]

        return (
        <form style={{
            display: 'flex',
            flexDirection: 'column',
            gap: '1.2rem'
        }}
              onSubmit={handleSubmit(onFinishHandler)}
        >
            <Typography fontSize={25} fontWeight={700} color="#ffffff">
                {type} a Property <span className={'step-count'}>(basic info)</span>
            </Typography>
            <InputCore
                key={'title'}
                label={'Enter property title'}
                error={errors.title?.message}
                register={register('title', {
                    required: {
                        value: true,
                        message: 'Property title is required'
                    }})}
                placeholder={'Enter a title'}
            />
            <SingleSelect items={typeMenuItems}
                          register={register('propertyType', {
                              required: {
                                  value: true,
                                  message: 'Property type is required'
                          }})}
                          selectedItemValue={getValues('propertyType')}
                          defaultValue={typeMenuItems[0]}
                          label={'Select Property Type'}
            />
            <div className={'grid-2-c'}>
                <InputWithSymbol
                    key={'area'}
                    label={'Enter area'}
                    error={errors.area?.message}
                    register={register('area', {
                        valueAsNumber: true,
                        required: {
                            value: true,
                            message: 'Property area is required'
                        }})}
                    type={'number'}
                    placeholder={'Enter a area'}
                    symbol={'m²'}
                    width={'100%'}
                />
                <SingleSelect items={roomItems}
                              register={register('roomsNumber', {
                                  required: {
                                      value: true,
                                      message: 'Property room number is required'
                                  }})}
                              selectedItemValue={getValues('roomsNumber')}
                              defaultValue={roomItems[0]}
                              label={'Select number of rooms'}
                />
            </div>
            <div className={'grid-2-c'}>
                <SingleSelect items={registerItems}
                              register={register('registerStatus', {
                                  required: {
                                      value: true,
                                      message: 'Property register status is required'
                                  }})}
                              selectedItemValue={getValues('registerStatus')}
                              defaultValue={registerItems[0]}
                              label={'Select register status'}
                />
                <SingleSelect items={conditionItems}
                              register={register('condition', {
                                  required: {
                                      value: true,
                                      message: 'Property register status is required'
                                  }})}
                              selectedItemValue={getValues('condition')}
                              defaultValue={conditionItems[0]}
                              label={'Select condition'}
                />
            </div>
            <div className={'grid-2-c'}>
                <SingleSelect items={heatingItems}
                              register={register('heating', {
                                  required: {
                                      value: true,
                                      message: 'Property heating  is required'
                                  }})}
                              selectedItemValue={getValues('heating')}
                              defaultValue={heatingItems[0]}
                              label={'Select heating'}
                />
                <SingleSelect items={elevatorItems}
                              register={register('elevatorsNumber', {
                                  valueAsNumber: true,
                                  required: {
                                      value: true,
                                      message: 'Property number of elevators is required'
                                  }})}
                              selectedItemValue={getValues('elevatorsNumber')}
                              defaultValue={elevatorItems[1]}
                              label={'Select number of elevators'}
                />
            </div>
            <div className={'grid-2-c'}>
                <SingleSelect items={floorItems}
                              register={register('floor', {
                                  required: {
                                      value: true,
                                      message: 'Property floor is required'
                                  }})}
                              selectedItemValue={getValues('floor')}
                              defaultValue={floorItems[1]}
                              label={'Select floor'}
                />
                <SingleSelect items={totalFloorItems}
                              register={register('totalFloors', {
                                  required: {
                                      value: true,
                                      message: 'Property total floors is required'
                                  }})}
                              selectedItemValue={getValues('totalFloors')}
                              defaultValue={totalFloorItems[0]}
                              label={'Select total floors'}
                />
            </div>
            <div className={'grid-2-c'}>
                <SingleSelect items={numberOfBathrooms}
                              register={register('bathroomsNumber', {
                                  valueAsNumber: true,
                                  required: {
                                      value: true,
                                      message: 'Property number of bathrooms is required'
                                  }})}
                              selectedItemValue={getValues('bathroomsNumber')}
                              defaultValue={numberOfBathrooms[0]}
                              label={'Select number of bathrooms'}
                />
                <SingleSelect items={numberOfBalconies}
                              register={register('balconiesNumber', {
                                  valueAsNumber: true,
                                  required: {
                                      value: true,
                                      message: 'Property number of balconies is required'
                                  }})}
                              selectedItemValue={getValues('balconiesNumber')}
                              defaultValue={numberOfBalconies[0]}
                              label={'Select number of balconies'}
                />
            </div>
            <div className={'grid-2-c'}>
                <SingleSelect items={numberOfBalconies}
                              register={register('toiletsNumber', {
                                  valueAsNumber: true,
                                  required: {
                                      value: true,
                                      message: 'Property number of toilets is required'
                                  }})}
                              selectedItemValue={getValues('toiletsNumber')}
                              defaultValue={numberOfBalconies[0]}
                              label={'Select number of toilets'}
                />
                <InputCore
                    key={'yearOfBuild'}
                    label={'Enter year of build'}
                    error={errors.yearOfBuild?.message}
                    type={'date'}
                    register={register('yearOfBuild', {
                        required: {
                            value: true,
                            message: 'Property year of build is required'
                        }})}
                    placeholder={'Enter a year of build'}
                />

            </div>
            <TextAreaBase
                key={'description'}
                placeholder={'Enter description'}
                register={register('description', {
                    required: {
                        value: true,
                        message: 'Property description is required'
                    }})}
                height={'12rem'}
                error={errors.description?.message}
                label={'Enter description'}
            />
            <div className={'btn-next'}>
                <ButtonWithIcon type={'submit'}
                                bgColor={'linear-gradient(97.05deg, #4066ff 3.76%, #2949c6 100%)'}
                                color={'#f5f8f2'}
                                icon={MdOutlineNavigateNext}
                                width={'20%'}
                                iconFirst={false}>
                    Next
                </ButtonWithIcon>
            </div>
        </form>
    );
};
