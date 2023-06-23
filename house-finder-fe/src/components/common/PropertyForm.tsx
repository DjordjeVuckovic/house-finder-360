import {FormProps} from "../../interfaces/common";
import {
  Box,
  FormControl,
  FormHelperText,
  TextareaAutosize,
  TextField,
  Typography,
  Stack,
  Select, MenuItem, Button, Stepper, Step, StepButton
} from "@pankod/refine-mui";
import {CustomButton} from "./CustomButton";
import {useState} from "react";

const steps = ["Step 1", "Step 2", "Step 3"];

const getStepContent = (step: number) => {
  switch (step) {
    case 0:
      return (
        <FormControl>
          <FormHelperText>Step 1 Content</FormHelperText>
        </FormControl>
      );
    case 1:
      return (
        <FormControl>
          <FormHelperText>Step 2 Content</FormHelperText>
        </FormControl>
      );
    case 2:
      return (
        <FormControl>
          <FormHelperText>Step 3 Content</FormHelperText>
        </FormControl>
      );
    default:
      return null;
  }
};

export const PropertyForm = ({type, register,onFinish,
  formLoading,handleSubmit,handleImageChange,onFinishHandler,propertyImage}:FormProps) => {
  const [activeStep, setActiveStep] = useState(0);
  const [completed, setCompleted] = useState<{
    [k: number]: boolean;
  }>({});

  const totalSteps = () => {
    return steps.length;
  };

  const completedSteps = () => {
    return Object.keys(completed).length;
  };

  const isLastStep = () => {
    return activeStep === totalSteps() - 1;
  };

  const allStepsCompleted = () => {
    return completedSteps() === totalSteps();
  };

  const handleNext = () => {
    const newActiveStep =
      isLastStep() && !allStepsCompleted()
        ? // It's the last step, but not all steps have been completed,
          // find the first step that has been completed
        steps.findIndex((step, i) => !(i in completed))
        : activeStep + 1;
    setActiveStep(newActiveStep);
  };

  const handleBack = () => {
    setActiveStep((prevActiveStep) => prevActiveStep - 1);
  };

  const handleStep = (step: number) => () => {
    setActiveStep(step);
  };

  const handleComplete = () => {
    const newCompleted = completed;
    newCompleted[activeStep] = true;
    setCompleted(newCompleted);
    handleNext();
  };

  const handleReset = () => {
    setActiveStep(0);
    setCompleted({});
  };
  return (
    <Box>
      <Typography fontSize={25} fontWeight={700} color="#11142d">
        {type} a Property
      </Typography>
      <Box mt={2.5} borderRadius="15px" padding="20px" bgcolor="#fcfcfc">
        <Stepper nonLinear activeStep={activeStep}>
          {steps.map((label, index) => (
            <Step key={label} completed={completed[index]}>
              <StepButton color="inherit" onClick={handleStep(index)}>
                {label}
              </StepButton>
            </Step>
          ))}
        </Stepper>
        <form style={{marginTop: '20px',
          width: '100%',
          display: 'flex',
          flexDirection: 'column',
          gap: '20px'
        }}
        onSubmit = {handleSubmit(onFinishHandler)}
        >
          <FormControl>
            <FormHelperText sx={{
              fontWeight: 600,
              margin: '10px',
              fontSize: 16,
              color: '#11142d'}}

            >Enter property title</FormHelperText>
              <TextField fullWidth
                         required
                         id="outlined-basic"
                         color="info"
                         type="text"
                         variant="outlined"
                         {...register('title', {required: true})}
              />
          </FormControl>
          <FormControl>
            <FormHelperText sx={{
              fontWeight: 600,
              margin: '10px',
              fontSize: 16,
              color: '#11142d'}}>
              Enter description
            </FormHelperText>
            <TextareaAutosize minRows={6}
                              required
                              id="outlined-basic"
                              placeholder="Write description"
                              style={{
                                width: '100%',
                                background: 'transparent',
                                fontSize: '16px',
                                borderColor: 'rgba(0,0,0,0.24)',
                                borderRadius: 6,
                                padding: 10, color: '#919191'
                              }}
                              color="info"
                              {...register('description', {required: true})}
            />
          </FormControl>
          <Stack direction ="row" gap={4}>
            <FormControl sx={{flex: 1}}>
              <FormHelperText sx={{
                fontWeight: 600,
                margin: '10px 0',
                fontSize: 16,
                color: '#11142d'}}>
                Select Property Type
              </FormHelperText>
              <Select
                variant="outlined"
                color="info"
                displayEmpty
                required
                inputProps = {{'aria-label': 'Without label'}}
                defaultValue = "apartment"
                {...register('propertyType', {required: true})}
              >
                <MenuItem value="apartment">
                  Apartment
                </MenuItem>
                <MenuItem value="villa">
                  Villa
                </MenuItem>
                <MenuItem value="Garage">
                  Garage
                </MenuItem>
              </Select>
            </FormControl>
            <FormControl>
              <FormHelperText sx={{
                fontWeight: 600,
                margin: '10px',
                fontSize: 16,
                color: '#11142d'}}
              >Enter price</FormHelperText>
              <TextField fullWidth
                         required
                         id="outlined-basic"
                         color="info"
                         variant="outlined"
                         type="number"
                         {...register('title', {required: true})}
              />
            </FormControl>
          </Stack>
          <FormControl>
            <FormHelperText sx={{
              fontWeight: 600,
              margin: '10px',
              fontSize: 16,
              color: '#11142d'}}
            >Enter location</FormHelperText>
            <TextField fullWidth
                       required
                       id="outlined-basic"
                       color="info"
                       variant="outlined"
                       type="text"
                       {...register('title', {required: true})}
            />
          </FormControl>
          <Stack direction="column" gap={1}
                 justifyContent="center"
                 mb={2}
          >
            <Stack direction="row" gap={2}>
              <Typography fontSize={16} fontWeight={600} color="#11142d" my="10px">
                Property photo
              </Typography>
              <Button component="label" sx={{
                width: 'fit-content',
                color: '#2ed480',
                textTransform: 'capitalize',
                fontSize: 16
              }}>
              Upload *
                <input
                  hidden
                  accept="image/*"
                  type= "file"
                  onChange={(e)=>
                    // @ts-ignore
                    handleImageChange(e.target.files[0])
                }
                />
              </Button>
            </Stack>
            <Typography fontSize={14} fontWeight={500} color="#808191"
                        sx={{wordBreak: 'break-all'}}
            >
              {propertyImage?.name}
            </Typography>
          </Stack>
          <CustomButton type="submit"
                        title={formLoading ? 'Submitting...' : 'Submit'}
                        bgColor="#475be8"
                        color="#fcfcfc"
          />
        </form>
      </Box>
    </Box>
  );
}