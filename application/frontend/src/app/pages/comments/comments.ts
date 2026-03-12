import { Component} from '@angular/core';
import { CiberforoHeader } from "../../components/ciberforo-header/ciberforo-header";
import { PostComment } from '../../components/post-comment/post-comment';
import { Topic } from "../../components/topic/topic";
import { CiberforoSidebar } from "../../components/ciberforo-sidebar/ciberforo-sidebar";

@Component({
  selector: 'app-comments',
  imports: [CiberforoHeader, PostComment, Topic, CiberforoSidebar],
  templateUrl: './comments.html',
  styleUrl: './comments.css',
})
export class Comments {

}
