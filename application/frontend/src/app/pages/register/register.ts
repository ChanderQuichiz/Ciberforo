import { Component, inject } from '@angular/core';
import { ReactiveFormsModule , Validators, NonNullableFormBuilder } from '@angular/forms';
import { UserService } from '../../services/user-service';
import { Router } from '@angular/router';
import { UserLogin } from '../../models/UserLogin';
@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './register.html',
  styleUrl: './register.css',
})
export class Register {
  private router = inject(Router);
  private userService = inject(UserService);
  private fb = inject(NonNullableFormBuilder);
  registerForm = this.fb.group({
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(8)]],
  });
  onSubmit() {
    if(!this.registerForm.valid) {
      console.log('Form is invalid');
    }
    else {
      console.log(this.registerForm.value);
      this.userService.createUser(this.registerForm.getRawValue() ).subscribe({
        next: (user) => {
          console.log('Usuario creador exitosamente:', user);
          this.userService.loginUser({ email: this.registerForm.value.email , password: this.registerForm.value.password } as UserLogin).subscribe({
            next: (loggedInUser) => {
              console.log('Usuario logueado exitosamente:', loggedInUser);
              localStorage.setItem('userdata', JSON.stringify(loggedInUser));
              this.router.navigate(['/']);
            },
              error: (error) => {
                console.error('Credenciales incorrectas', error);
              }
          });
        },
        error: (error) => {
          console.error('No se pudo crear el usuario:', error);
        }
      })
    }
  }
}
