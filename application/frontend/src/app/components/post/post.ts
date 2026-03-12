import { Component, inject } from '@angular/core';
import { ReactiveFormsModule ,NonNullableFormBuilder, Validators } from '@angular/forms';
import { TopicService } from '../../services/topic-service';
@Component({
  selector: 'app-post',
  imports: [ReactiveFormsModule],
  templateUrl: './post.html',
  styleUrl: './post.css',
})
export class Post {
 private fb:NonNullableFormBuilder = inject(NonNullableFormBuilder)
 private topicService = inject(TopicService) 
 postForm = this.fb.group({
    content: ['', [Validators.required, Validators.minLength(1)]],
    title: ['', [Validators.required, Validators.minLength(1)]],
    userId: [JSON.parse(localStorage.getItem("userdata") as string).id, [Validators.required, Validators.min(1)]],
  });
  onSubmit(){
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
