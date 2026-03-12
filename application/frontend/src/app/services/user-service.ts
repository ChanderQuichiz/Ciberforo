import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserCreate } from '../models/UserCreate';
import { Observable } from 'rxjs';
import { User } from '../models/User';
import { UserLogin } from '../models/UserLogin';
@Injectable({
  providedIn: 'root',
})
export class UserService {
  private apiUrl:string = 'http://localhost:5124/api/user';
  http: HttpClient = inject(HttpClient);
   createUser(user: UserCreate): Observable<User>  {
    return this.http.post<User>(this.apiUrl+'/create', user);
  }
  updateUser(user: User):Observable<void> {
    return this.http.put<void>(this.apiUrl+'/update', user);
  }
  deleteUser(userId: number):Observable<void> {
    return this.http.delete<void>(this.apiUrl+'/delete/' + userId);
  }
  bannedUser(userId: number):Observable<void> {
    return this.http.put<void>(this.apiUrl+'/ban/' + userId, null);
  }
  loginUser(userLogin: UserLogin): Observable<User> {
    return this.http.post<User>(this.apiUrl + '/login', userLogin);
  }

}
