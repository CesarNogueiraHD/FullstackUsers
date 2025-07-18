import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import type { CreateUser, User, UserDetails } from '../types/user';
import { map, type Observable } from 'rxjs';
import { environment } from '../../../../environments/environment.development';
import type { ResultData } from '../../../shared/types/ResultData';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private httpClient = inject(HttpClient);

  getUsers(): Observable<ResultData<User[]>> {
    const result = this.httpClient.get<ResultData<User[]>>(
      `${environment.apiUrl}/api/Users`
    );
    return result;
  }

  createUser(user: CreateUser): Observable<UserDetails> {
    const result = this.httpClient.post<UserDetails>(
      `${environment.apiUrl}/api/users`,
      user
    );
    return result;
  }
}
