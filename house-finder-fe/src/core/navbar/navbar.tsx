import "./navbar.scss"
import logo from "../../assets/logo.png";
import {NavLink} from "./ui/nav-link.tsx";
import {NavButton} from "./ui/nav-button.tsx";
export const Navbar = () => {
    return (
     <nav className='navbar-wrapper'>
         <section className='padding-base inner-width navbar-container'>
             <div className={'flex-center logo-container'}>
                 <img src={logo} alt={'logo'} className={'image-logo'} loading='lazy'/>
             </div>
             <div className='flex-center navbar-menu-middle'>
                 <NavLink title={'Home'} url={'/home'}/>
                 <NavLink title={'Main'} url={''}/>
                 <NavButton title={'Contact'} link={'/contact'}/>
             </div>
             <div className='flex-end navbar-menu-end'>
                 <NavLink title={'Sign In'} url={'/sign-in'}/>
                 <NavLink title={'Sign Up'} url={'/sign-up'}/>
             </div>
         </section>
     </nav>
    );
}