import { Component, inject } from '@angular/core';
import { ReactiveFormsModule ,NonNullableFormBuilder, Validators } from '@angular/forms';
import { TopicService } from '../../services/topic-service';
import { User } from '../../models/User';
@Component({
  selector: 'app-post',
  imports: [ReactiveFormsModule],
  templateUrl: './post.html',
  styleUrl: './post.css',
})
export class Post {
 private fb:NonNullableFormBuilder = inject(NonNullableFormBuilder)
 private topicService = inject(TopicService)
 private userData: User | null = JSON.parse(localStorage.getItem('userdata') as string)

 postForm = this.fb.group({
    content: ['', [Validators.required, Validators.minLength(1)]],
    title: ['', [Validators.required, Validators.minLength(1)]],
    userId: [this.userData?.id ?? 0, [Validators.required, Validators.min(1)]],
  });
  onSubmit(){
    if (!this.userData?.id) {
      console.log('No hay usuario logueado para crear el tema');
      return;
    }

    if(!this.postForm.valid) {
      console.log('Form is invalid');
    }
    else {
      this.topicService.createTopic(this.postForm.getRawValue()).subscribe({
        next: (topic) => {
          console.log('Tema creado exitosamente:', topic);
        },
        error: (error) => {
          console.error('No se pudo crear el tema:', error);
        }
      })
      this.postForm.reset();
    }
  }
}
