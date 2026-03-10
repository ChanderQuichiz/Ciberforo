import { Component } from '@angular/core';
import { CiberforoHeader } from '../../components/ciberforo-header/ciberforo-header';
import { CiberforoSidebar } from '../../components/ciberforo-sidebar/ciberforo-sidebar';
import { Post } from '../../components/post/post';

import { Topic } from '../../components/topic/topic';
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
export class Home {
 
}
