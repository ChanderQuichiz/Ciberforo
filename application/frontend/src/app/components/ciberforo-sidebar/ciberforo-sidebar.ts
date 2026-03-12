import { Component } from '@angular/core';

@Component({
  selector: 'app-ciberforo-sidebar',
  imports: [],
  templateUrl: './ciberforo-sidebar.html',
  styleUrl: './ciberforo-sidebar.css',
})
export class CiberforoSidebar {
  userData = JSON.parse(localStorage.getItem('userdata') as string);
}
