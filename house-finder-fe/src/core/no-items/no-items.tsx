import { Typography } from '@mui/material'

export const NoItems = ({
  imgSrc,
  imgWidth,
  imgHeight,
  content,
  contentColor,
  position,
}) => {
  return (
    <div
      className={position === 'center' ? 'flex-col-center' : 'flex-col-start'}
    >
      <img src={imgSrc} alt={'no-items'} width={imgWidth} height={imgHeight} />
      <Typography fontSize={20} fontWeight={700} color={contentColor}>
        {content}
      </Typography>
    </div>
  )
}
