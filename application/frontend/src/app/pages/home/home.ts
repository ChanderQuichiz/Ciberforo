import { Component, inject, OnInit } from '@angular/core';
import { CiberforoHeader } from '../../components/ciberforo-header/ciberforo-header';
import { CiberforoSidebar } from '../../components/ciberforo-sidebar/ciberforo-sidebar';
import { Post } from '../../components/post/post';

import { Topic } from '../../components/topic/topic';
import { User } from '../../models/User';
import { Router } from '@angular/router';
type FeedPost = {
  id: number;
  author: string;
  content: string;
  likes: number;
  comments: number;
  showReportMenu?: boolean;
};

@Component({
  selector: 'app-home',
  imports: [CiberforoHeader, CiberforoSidebar, Post, Topic],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home implements OnInit {
  router = inject(Router);
  userData:User = JSON.parse(localStorage.getItem('userdata') as string)
  constructor() {}
  ngOnInit() {
    if (this.userData) {
      console.log('Usuario logueado:', this.userData);
    }
    else{
      console.log('No hay usuario logueado');
      this.router.navigate(['/login']);
    }
}
}
