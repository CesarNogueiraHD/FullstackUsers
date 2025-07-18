import { ChangeDetectionStrategy, Component, Input } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import type { User } from '../../types/user';

@Component({
  selector: 'app-user-card',
  standalone: true,
  imports: [MatCardModule],
  templateUrl: './user-card.component.html',
  styleUrl: './user-card.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class UserCardComponent {
  @Input() user!: User;
}
