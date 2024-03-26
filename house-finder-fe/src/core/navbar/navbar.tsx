import './navbar.scss'
import logo from '../../assets/logo.png'
import { NavLink } from './ui/nav-link.tsx'
import { NavButton } from './ui/nav-button.tsx'
import { useUserPayload } from '../../auth/use-get-user.ts'
import { ButtonAsLink } from './ui/button-as-link.tsx'
import useAuthStore from '../../auth/auth-store.ts'
import { useNavigate } from 'react-router-dom'
import { useToast } from '../../shared/toast-messages/use-toast.ts'
import {
  AiOutlineLogin,
  AiOutlineLogout,
  AiOutlineUserAdd,
} from 'react-icons/ai'
export const Navbar = () => {
  const user = useUserPayload()
  const { setAccessToken } = useAuthStore()
  const navigate = useNavigate()
  const { showToast } = useToast()
  const logOut = () => {
    setAccessToken(null)
    navigate('')
    showToast('You have been logged out', 'success')
  }
  return (
    <nav className='navbar-wrapper'>
      <section className='padding-base inner-width navbar-container'>
        <div className={'flex-center logo-container'}>
          <img
            src={logo}
            alt={'logo'}
            className={'image-logo'}
            loading='lazy'
            onClick={() => navigate('')}
          />
        </div>
        <div className='flex-center navbar-menu-middle'>
          <NavLink url={''}>Home</NavLink>
          {user && <NavLink url={'/dashboard'}>Dashboard</NavLink>}
          {user && (
            <NavLink url={'/rental-manager/all-properties'}>
              Rental Manager
            </NavLink>
          )}
          <NavButton title={'Contact'} link={'/contact'} />
        </div>
        <div className='flex-end navbar-menu-end'>
          {!user && (
            <NavLink url={'/sign-up'}>
              Sign Up <AiOutlineUserAdd size={25} />
            </NavLink>
          )}
          {!user && (
            <NavLink url={'/sign-in'}>
              Sign In <AiOutlineLogin size={20} />
            </NavLink>
          )}
          {user && (
            <ButtonAsLink onClick={logOut}>
              Log out <AiOutlineLogout size={20} />
            </ButtonAsLink>
          )}
        </div>
      </section>
    </nav>
  )
}
