import { Component, inject } from '@angular/core';
import { AuthService } from '../../../core/auth/auth.service';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-sidenav',
  standalone: true,
  imports: [MatIconModule],
  templateUrl: './sidenav.component.html',
  styleUrl: './sidenav.component.css',
})
export class SidenavComponent {
  private authService = inject(AuthService);

  logout() {
    this.authService.logout();
  }
}
