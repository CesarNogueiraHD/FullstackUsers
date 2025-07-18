import type { HttpInterceptorFn } from '@angular/common/http';
import { AUTH_TOKEN } from '../keys';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const token = localStorage.getItem(AUTH_TOKEN);
  if (token) {
    const authorizedRequest = req.clone({
      headers: req.headers.set('Authorization', `Bearer ${token}`),
    });

    return next(authorizedRequest);
  }
  return next(req);
};
