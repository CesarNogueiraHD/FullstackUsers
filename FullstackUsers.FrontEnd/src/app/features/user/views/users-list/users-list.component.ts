import {
  ChangeDetectionStrategy,
  Component,
  inject,
  type ChangeDetectorRef,
  type OnInit,
} from '@angular/core';
import { UserCardComponent } from '../../components/user-card/user-card.component';
import type { User } from '../../types/user';
import { CommonModule } from '@angular/common';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-users-list',
  standalone: true,
  imports: [CommonModule, UserCardComponent],
  templateUrl: './users-list.component.html',
  styleUrl: './users-list.component.css',
  changeDetection: ChangeDetectionStrategy.Default,
})
export class UsersListComponent {
  constructor(private userService: UserService) {
    this.userService.getUsers().subscribe((result) => {
      this.users = result.items;
    });
  }

  users: User[] = [];
}
