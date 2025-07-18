export interface User {
  name: string;
  email: string;
  birth?: string;
}

export interface UserDetails extends User {
  id: string;
}

export interface CreateUser {
  name: string;
  email: string;
  password: string;
  passwordConfirmation: string;
  birth?: string;
}
