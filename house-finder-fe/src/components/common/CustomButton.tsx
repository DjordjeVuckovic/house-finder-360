import {CustomButtonProps} from "../../interfaces/common";
import {Button} from "@pankod/refine-mui";

export const CustomButton = ({title,type,bgColor
  , color,fullWidth,icon,handleClick}:CustomButtonProps) => {
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
        textTransform: 'capitalize',
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