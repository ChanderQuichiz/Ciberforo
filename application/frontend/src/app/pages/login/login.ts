import { Component, inject } from '@angular/core';
import { NonNullableFormBuilder, ReactiveFormsModule } from '@angular/forms';
import { FormBuilder, Validators } from '@angular/forms';
import { UserService } from '../../services/user-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  router = inject(Router);
  private fb = inject(NonNullableFormBuilder);
  private userService = inject(UserService);
  loginForm = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(8)]],
  });

  onSubmit() {
    if (!this.loginForm.valid) {
      console.log('Form is invalid');
    }
      else {
        this.userService.loginUser(this.loginForm.getRawValue()).subscribe({
                    next: (loggedInUser) => {
                      console.log('Usuario logueado exitosamente:', loggedInUser);
                      localStorage.setItem('userdata', JSON.stringify(loggedInUser));
                      this.router.navigate(['/home']);
                    },
                      error: (error) => {
                        console.error('Credenciales incorrectas', error);
                      }
                  });
      }
  }
}