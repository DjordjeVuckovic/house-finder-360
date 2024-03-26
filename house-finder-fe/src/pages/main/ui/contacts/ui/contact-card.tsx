import '../contacts.scss'
export interface ContactCardProps {
  title: string
  text: string
  icon?: any
  onClick?: () => void
  buttonText: string
}
export const ContactCard = ({
  title,
  text,
  icon: Icon,
  onClick,
  buttonText,
}: ContactCardProps) => {
  return (
    <div className={'contact-card'}>
      <div className={'flex-wrap'}>
        <div className={'contact-card-icon'}>
          {Icon && <Icon color={'#3D5CB8FF'} size={25} />}
        </div>
        <div className={'contact-card-content'}>
          <div className={'primary-text-small'}>{title}</div>
          <div className={'secondary-text'}>{text}</div>
        </div>
      </div>
      <button className={'btn-contact'} onClick={onClick}>
        {buttonText}
      </button>
    </div>
  )
}
