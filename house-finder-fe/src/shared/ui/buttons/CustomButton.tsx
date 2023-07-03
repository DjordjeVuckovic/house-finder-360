import {Button} from "@mui/material";
import {CustomButtonProps} from "../../common";


export const CustomButton = ({title,bgColor
  ,color,fullWidth,icon,handleClick,isCapital}:CustomButtonProps) => {
  return (
    <Button
      sx={{
        flex: fullWidth ? 1 : 'unset',
        padding: '10px 15px',
        width: fullWidth ? '100%' : 'fit-content',
        backgroundColor:bgColor,
        color,
        fontSize: 16,
        fontWeight: 600,
        gap: '10px',
        textTransform: isCapital ? 'uppercase' : 'lowercase',
        '&:hover': {
          opacity: 0.9,
          backgroundColor:bgColor
        }
      }}
      onClick={handleClick}
    >
      {icon}
      {title}
    </Button>
  );
}