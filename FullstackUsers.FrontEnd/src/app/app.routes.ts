import { Routes } from '@angular/router';
import { UsersListComponent } from './features/user/views/users-list/users-list.component';
import { CreateUserComponent } from './features/user/views/create-user/create-user.component';
import { authGuard } from './core/auth/auth.guard';
import { LoginPageComponent } from './features/auth/views/login-page/login-page.component';

export const routes: Routes = [
  {
    path: 'users',
    component: UsersListComponent,
    canActivate: [authGuard],
  },
  {
    path: 'users/create',
    component: CreateUserComponent,
    canActivate: [authGuard],
  },
  {
    path: 'login',
    component: LoginPageComponent,
  },
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full',
  },
];
