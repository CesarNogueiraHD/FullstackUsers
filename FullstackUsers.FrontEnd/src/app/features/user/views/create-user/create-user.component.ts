import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { NgxMaskDirective, provideNgxMask } from 'ngx-mask';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import moment from 'moment';

@Component({
  selector: 'app-create-user',
  standalone: true,
  imports: [
    MatInputModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    CommonModule,
    NgxMaskDirective,
    MatDialogModule,
    ToastrModule,
  ],
  templateUrl: './create-user.component.html',
  styleUrl: './create-user.component.css',
  providers: [provideNgxMask()],
})
export class CreateUserComponent {
  private userService = inject(UserService);
  router = inject(Router);
  toastr = inject(ToastrService);
  currentDate = new Date();

  form = new FormGroup({
    name: new FormControl('', Validators.required),
    email: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
    passwordConfirmation: new FormControl('', Validators.required),
    birth: new FormControl(''),
  });

  createUser() {
    const { birth, email, name, password, passwordConfirmation } =
      this.form.value;
    var formattedBirth = birth ? moment(birth, 'DD-MM-YYYY') : undefined;
    this.userService
      .createUser({
        name: name!,
        email: email!,
        password: password!,
        passwordConfirmation: passwordConfirmation!,
        birth: formattedBirth?.format('YYYY-MM-DD'),
      })
      .subscribe({
        next: (value) => {
          this.toastr.success('Usuário cadastrado com sucesso!', 'Sucesso');
          this.router.navigate(['/users']);
        },
        error: (err) => {
          this.toastr.error(err.error, 'Erro');
        },
      });
  }
}
