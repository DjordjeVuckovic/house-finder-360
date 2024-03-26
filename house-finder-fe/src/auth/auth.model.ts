export interface SignInRequest {
  emailOrPhone: string
  password: string
}
export interface SignUpForm {
  email: string
  firstName: string
  lastName: string
  phone: string
  password: string
  confirmPassword: string
}
export interface SignUpRequest {
  email: string
  firstName: string
  lastName: string
  phone: string
  password: string
  role: string
}
