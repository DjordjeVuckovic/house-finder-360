import './App.scss'
import './core/navbar/index.ts'
import {Navbar} from "./core/navbar";
import {Route, Routes} from "react-router-dom";
import {HomePage} from "./pages/home";
import {MainPage} from "./pages/main";
import {Body} from "./core/body";
import {ContactPage} from "./pages/contact";
import {SignInPage} from "./pages/sign-in/sign-in.page.tsx";
import {SignUpPage} from "./pages/sign-up/sign-up.page.tsx";


function App() {
  return (
      <>
        <Navbar/>
          <Body>
              <Routes>
                  <Route path='/home' element={<HomePage/>}/>
                  <Route path='/' element={<MainPage/>}/>
                  <Route path='/contact' element={<ContactPage/>}/>
                  <Route path='/sign-in' element={<SignInPage/>}/>
                  <Route path='/sign-up' element={<SignUpPage/>}/>
              </Routes>
          </Body>
      </>
  )
}

export default App
