import './App.scss'
import './core/navbar/index.ts'
import {Navbar} from "./core/navbar";
import {Route, Routes} from "react-router-dom";
import {DashboardPage} from "./pages/dashboard";
import {HomePage} from "./pages/main";
import {Body} from "./shared/ui/body";
import {ContactPage} from "./pages/contact";
import {SignInPage} from "./pages/sign-in/sign-in.page.tsx";
import {SignUpPage} from "./pages/sign-up/sign-up.page.tsx";
import {PropertyFormPage} from "./pages/create-property";
import {UsersProperties} from "./pages/user-properties";
import {Fragment} from "react";
import {QueryClient, QueryClientProvider} from "react-query";
import {ToastProvider} from "./shared/toast-messages";
import {PropertiesMapPage} from "./pages/property-map/properties-map.page.tsx";

const queryClient = new QueryClient();
function App() {
  return (
      <Fragment>
          <QueryClientProvider client={queryClient}>
              <ToastProvider>
                  <Navbar/>
                  <Body>
                      <Routes>
                          <Route path='/dashboard' element={<DashboardPage/>}/>
                          <Route path='/' element={<HomePage/>}/>
                          <Route path='/contact' element={<ContactPage/>}/>
                          <Route path='/sign-in' element={<SignInPage/>}/>
                          <Route path='/sign-up' element={<SignUpPage/>}/>
                          <Route path='/create-property' element={<PropertyFormPage type={'Create'}/>}/>
                          <Route path='/rental-manager/*' element={<UsersProperties/>}/>
                          <Route path='/properties' element={<PropertiesMapPage/>}/>
                      </Routes>
                  </Body>
            </ToastProvider>
          </QueryClientProvider>
      </Fragment>
  )
}

export default App
