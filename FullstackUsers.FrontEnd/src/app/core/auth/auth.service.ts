import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import type { UserLoginRequest, UserLoginResponse } from './types/UserLogin';
import { environment } from '../../../environments/environment.development';
import { BehaviorSubject, tap, type Observable } from 'rxjs';
import { AUTH_TOKEN } from '../keys';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private httpClient = inject(HttpClient);
  private router = inject(Router);
  private toastr = inject(ToastrService);

  login(login: UserLoginRequest) {
    this.httpClient
      .post<UserLoginResponse>(`${environment.apiUrl}/api/Auth`, login)
      .subscribe({
        next: (result) => {
          localStorage.setItem(AUTH_TOKEN, result.accessToken);
          this.router.navigate(['/users']);
          this.isAuthenticatedObservable.next(true);
        },
        error: (err) => {
          this.toastr.error(err.error, 'Erro!');
        },
      });
  }
  logout(): void {
    localStorage.removeItem(AUTH_TOKEN);
    this.isAuthenticatedObservable.next(false);
  }
  getToken(): string | null {
    return localStorage.getItem(AUTH_TOKEN);
  }
  private isAuthenticatedObservable = new BehaviorSubject<boolean>(
    !!this.getToken()
  );

  isAuthenticated = this.isAuthenticatedObservable.asObservable();
}
