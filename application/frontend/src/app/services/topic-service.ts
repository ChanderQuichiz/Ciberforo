import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { inject } from '@angular/core';
import { TopicCreate } from '../models/TopicCreate';
import { Topic } from '../components/topic/topic';
import { TopicUpdate } from '../models/TopicUpdate';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class TopicService {
  http:HttpClient = inject(HttpClient);
  private apiUrl:string = 'http://localhost:5124/api/topic';
  createTopic(topic: TopicCreate):Observable<Topic> {
    return this.http.post<Topic>(this.apiUrl + '/create', topic);
  }
  updateTopic(topic:TopicUpdate):Observable<void> {
    return this.http.put<void>(this.apiUrl + '/update', topic);
  }
  deleteTopic(topicId: number):Observable<void> {
    return this.http.delete<void>(this.apiUrl + '/delete/' + topicId);
  }
}
