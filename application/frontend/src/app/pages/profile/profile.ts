import { Component, inject } from '@angular/core';
import { CiberforoHeader } from "../../components/ciberforo-header/ciberforo-header";
import { CiberforoSidebar } from "../../components/ciberforo-sidebar/ciberforo-sidebar";
import { Topic } from "../../components/topic/topic";
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { NonNullableFormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { UserService } from '../../services/user-service';
@Component({
  selector: 'app-profile',
  imports: [CiberforoHeader, CiberforoSidebar,ReactiveFormsModule, Topic, ButtonModule, DialogModule, InputTextModule],
  templateUrl: './profile.html',
  styleUrl: './profile.css',
})
export class Profile {
 visible: boolean = false;
 private userService = inject(UserService);
    showDialog() {
        this.visible = true;
    }
  private fb: NonNullableFormBuilder = inject(NonNullableFormBuilder);
  profileForm = this.fb.group({
    firstName:['',[ Validators.required, Validators.minLength(1)]],
    lastName:['',[ Validators.required, Validators.minLength(1)]],
    email:['',[ Validators.required, Validators.email]],
    password:['',[ Validators.required, Validators.minLength(8)]],
    id: [JSON.parse(localStorage.getItem('userdata') as string)?.id , [Validators.required, Validators.min(1)]]
  });
  onSubmit(){
    if(!this.profileForm.valid) {
      console.log('Form is invalid');
    }
    else{
      this.userService.updateUser(this.profileForm.getRawValue()).subscribe({
        next: (updatedUser) => {
          console.log('Usuario actualizado exitosamente:', updatedUser);
        },
        error: (error) => {
          console.error('No se pudo actualizar el usuario:', error);
        }
    });
  }
  }
}

