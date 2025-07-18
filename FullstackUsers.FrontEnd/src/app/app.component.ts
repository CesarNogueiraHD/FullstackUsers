import { Component, inject } from '@angular/core';
import { RouterOutlet, ɵEmptyOutletComponent } from '@angular/router';
import { MatSidenavModule } from '@angular/material/sidenav';
import { SidenavComponent } from './shared/components/sidenav/sidenav.component';
import { AuthService } from './core/auth/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, MatSidenavModule, SidenavComponent, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  private authService = inject(AuthService);

  title = 'Fullstack Users';
  isAuthenticated = false;

  constructor() {
    this.authService.isAuthenticated.subscribe((status) => {
      this.isAuthenticated = status;
    });
  }
}
