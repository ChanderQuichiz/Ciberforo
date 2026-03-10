import { Component } from '@angular/core';
type FeedPost = {
  id: number;
  author: string;
  content: string;
  likes: number;
  comments: number;
  showReportMenu?: boolean;
};

@Component({
  selector: 'app-post',
  imports: [],
  templateUrl: './post.html',
  styleUrl: './post.css',
})
export class Post {
   protected readonly posts: FeedPost[] = [
    {
      id: 1,
      author: 'Lucia Chang',
      content:
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Ex cupiditate, saepe beatae in blanditiis dolores reprehenderit nemo, accusantium ratione, eveniet itaque exercitationem hic obcaecati nam explicabo illum fugiat quas dolore.',
      likes: 42,
      comments: 42,
    },
    {
      id: 2,
      author: 'Lucia Chang',
      content:
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Ex cupiditate, saepe beatae in blanditiis dolores reprehenderit nemo, accusantium ratione, eveniet itaque exercitationem hic obcaecati nam explicabo illum fugiat quas dolore.',
      likes: 42,
      comments: 42,
      showReportMenu: true,
    },
    {
      id: 3,
      author: 'Lucia Chang',
      content:
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Ex cupiditate, saepe beatae in blanditiis dolores reprehenderit nemo, accusantium ratione, eveniet itaque exercitationem hic obcaecati nam explicabo illum fugiat quas dolore.',
      likes: 42,
      comments: 42,
    },
  ];
}
